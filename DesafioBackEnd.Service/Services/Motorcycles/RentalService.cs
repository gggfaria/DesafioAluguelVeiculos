using AutoMapper;
using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Interfaces.Motorcycles;
using DesafioBackEnd.Service.Response;
using Microsoft.Extensions.Logging;

namespace DesafioBackEnd.Service.Services.Motorcycles;

public class RentalService : IRentalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<RentalService> _logger;

    public RentalService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RentalService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    private async Task<IEnumerable<Plan>> GetPlanAvailable()
    {
        return await _unitOfWork.Plan.FindAsync(p => p.IsActive);
    }

    public async Task<ResultService> RentMotorcycle(CreateRentalDto dto)
    {
        var rental = _mapper.Map<Rental>(dto);

        var plan = await GetPlanByDate(rental);
        if (plan is null)
            return ResultServiceFactory.BadRequest("No valid plans for this amount of days");

        rental.SetPlanId(plan.Id);

        var driver = await _unitOfWork.Driver.GetAsync(rental.DriverId);

        if (!rental.IsValid(driver))
            return ResultServiceFactory.BadRequest(rental.GetInvalidData(), "Invalid data");

        if (await ValidateMotorcycleId(rental))
            return ResultServiceFactory.BadRequest("Motorcycle not found");

        await _unitOfWork.Rental.AddAsync(rental);
        var result = await _unitOfWork.CommitAsync();

        if (!result)
        {
            _logger.LogError("Error commit add rental. Object rental {rental}", rental);
            return ResultServiceFactory.InternalServerError("Created has failed");
        }

        return ResultServiceFactory<ViewRentalDto>.Created(_mapper.Map<ViewRentalDto>(rental));
    }

    public async Task<ResultService> GetRentalPrice(DateTime returnDate, Guid driverId)
    {
        var rentals = (await _unitOfWork.Rental.FindAllActiveFromDriver(driverId)).ToList();
        if (rentals?.Count() < 1)
            return ResultServiceFactory.NoContent();

        foreach (var rental in rentals)
        {
            rental!.SetEndDate(returnDate);
            if (!rental.IsValid())
                return ResultServiceFactory.BadRequest(rental.GetInvalidData(), "Invalid data");
        }

        return ResultServiceFactory<IEnumerable<RentalPriceDto>>
            .Ok(_mapper.Map<IEnumerable<RentalPriceDto>>(rentals));
    }


    private async Task<bool> ValidateMotorcycleId(Rental rental)
    {
        return !await _unitOfWork.Motorcycle.EntityExists(p => p.Id == rental.MotorcycleId);
    }

    private async Task<Plan?> GetPlanByDate(Rental rental)
    {
        var plan = await _unitOfWork.Plan.GetRentalByDays(rental.GetAmountDaysEstimated());
        return plan;
    }
}