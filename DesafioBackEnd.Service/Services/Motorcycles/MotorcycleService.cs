using AutoMapper;
using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Interfaces.Motorcycles;
using DesafioBackEnd.Service.Response;
using Microsoft.Extensions.Logging;

namespace DesafioBackEnd.Service.Services.Motorcycles;

public class MotorcycleService : IMotorcycleService
{
    readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<MotorcycleService> _logger;
    
    public MotorcycleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MotorcycleService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ResultService> CreateMotorcycle(CreateMotorcycleDto dto)
    {
        var moto = _mapper.Map<Motorcycle>(dto);
        if (!moto.IsValid())
            return ResultServiceFactory.BadRequest(moto.GetInvalidData(), "Invalid data");

        if (await _unitOfWork.Motorcycle.EntityExists(p => p.LicencePlate == moto.LicencePlate))
            return ResultServiceFactory.BadRequest("Licence Plate already exists");


        await _unitOfWork.Motorcycle.AddAsync(moto);
        var result = await _unitOfWork.CommitAsync();

        if (!result)
        {
            _logger.LogError("Error commit add motorcycle. Object {@moto}", moto);
            return ResultServiceFactory.InternalServerError("Created has failed");
        }

        return ResultServiceFactory<ViewMotorcycleDto>.Created(_mapper.Map<ViewMotorcycleDto>(moto));
    }

    public async Task<ResultService> GetByLincence(string licencePlate)
    {
        if (string.IsNullOrEmpty(licencePlate))
            return ResultServiceFactory.BadRequest("Invalid value");

        var moto = await _unitOfWork.Motorcycle.GetByLicencePlate(licencePlate);

        if (moto is null)
            return ResultServiceFactory.NotFound("No motorcycle found");


        return ResultServiceFactory<ViewMotorcycleDto>.Ok(_mapper.Map<ViewMotorcycleDto>(moto));
    }

    public async Task<ResultService> GetAll()
    {
        var motorcycles = await _unitOfWork.Motorcycle.FindAsync(p => p.IsActive);

        if (motorcycles?.Count() < 1)
            return ResultServiceFactory<IEnumerable<ViewMotorcycleDto>>.NoContent(Enumerable.Empty<ViewMotorcycleDto>(),
                "No motorcycles found");


        return ResultServiceFactory<IEnumerable<ViewMotorcycleDto>>.Ok(
            _mapper.Map<IEnumerable<ViewMotorcycleDto>>(motorcycles));
    }

    public async Task<ResultService> UpdateLicencePlate(Guid motorcycleId, string licencePlate)
    {
        if (await _unitOfWork.Motorcycle.EntityExists(p => p.LicencePlate.Equals(licencePlate)))
            return ResultServiceFactory.BadRequest("Licence plate already exists");

        Motorcycle motorcycle = await _unitOfWork.Motorcycle.GetAsync(motorcycleId);

        if (motorcycle is null)
            return ResultServiceFactory.NotFound("No motorcycle found");

        motorcycle.UpdateLicence(licencePlate);

        _unitOfWork.Motorcycle.Update(motorcycle);
        var result = await _unitOfWork.CommitAsync();

        if (!result)
            return ResultServiceFactory.InternalServerError("Update has failed");

        return ResultServiceFactory.NoContent("Licence updated");
    }
    
    public async Task<ResultService> Delete(Guid motorcycleId)
    {
        Motorcycle motorcycle = await _unitOfWork.Motorcycle.GetByIdWithRentals(motorcycleId);

        if (motorcycle is null)
            return ResultServiceFactory.NotFound("No motorcycle found");
        if (motorcycle.Rentals?.Count() > 0)
            return ResultServiceFactory.BadRequest("This motorcycle has rentals");

        _unitOfWork.Motorcycle.Remove(motorcycle);
        var result = await _unitOfWork.CommitAsync();

        if (!result)
            return ResultServiceFactory.InternalServerError("Delete has failed");

        return ResultServiceFactory.NoContent("Motorcycle has been deleted");
    }
}