using AutoMapper;
using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Service.DTOs.Motorcycles;

namespace DesafioBackEnd.Api.Profiles;

public class ProfileMotorcycles : Profile
{
    public ProfileMotorcycles()
    {
        CreateMap<Motorcycle, ViewMotorcycleDto>();
        CreateMap<CreateMotorcycleDto, Motorcycle>();
    }
}