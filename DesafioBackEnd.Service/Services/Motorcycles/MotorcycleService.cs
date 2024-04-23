using AutoMapper;
using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Interfaces.Motorcycles;
using DesafioBackEnd.Service.Response;

namespace DesafioBackEnd.Service.Services.Motorcycles;

public class MotorcycleService : IMotorcycleService
{
    readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MotorcycleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultService> CreateMotorcycle(CreateMotorcycleDto dto)
    {
        var moto = _mapper.Map<Motorcycle>(dto);
        if (!moto.IsValid())
            return ResultServiceFactory.BadRequest(moto.GetInvalidData(), "Invalid data");
        
        if(await _unitOfWork.Motorcycle.EntityExists(p => p.LicencePlate == moto.LicencePlate))
            return ResultServiceFactory.BadRequest("Licence Plate already exists");
            

        await _unitOfWork.Motorcycle.AddAsync(moto);
        var result = await _unitOfWork.CommitAsync();

        if (!result) 
            return ResultServiceFactory.InternalServerError("Created has failed");
        
        return ResultServiceFactory<ViewMotorcycleDto>.Created(_mapper.Map<ViewMotorcycleDto>(moto));
        
    }
}