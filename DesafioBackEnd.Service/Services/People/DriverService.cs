using AutoMapper;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Interfaces.People;
using DesafioBackEnd.Service.Response;

namespace DesafioBackEnd.Service.Services.People;

public class DriverService : IDriverService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<ResultService> CreateDriver(CreateDriverDto dto)
    {
        var driver = _mapper.Map<Driver>(dto);
        if (!driver.IsValid())
            return ResultServiceFactory.BadRequest(driver.GetInvalidData(), "Invalid data");
        
        await _unitOfWork.Driver.AddAsync(driver);
        var result = await _unitOfWork.CommitAsync();

        if (!result)
            return ResultServiceFactory.InternalServerError("Created has failed");

        return ResultServiceFactory<ViewDriverDto>.Created(_mapper.Map<ViewDriverDto>(driver));
    }
    
}