using AutoMapper;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Entities.ValueObjects;
using DesafioBackEnd.Service.DTOs.People;

namespace DesafioBackEnd.Api.Profiles;

public class ProfilePeople : Profile
{ 
    public ProfilePeople()
    {
        CreateMap<CreateDriverDto, Driver>()
            .ForMember(
                dest => dest.Cnpj,
                opt => opt.MapFrom(src => new CNPJ(src.Cnpj))
            );
     
        
        CreateMap<Driver, ViewDriverDto>()
            .ForMember(
                dest => dest.Cnpj,
                opt => opt.MapFrom(src => src.Cnpj.Number)
            );

    }
    
}