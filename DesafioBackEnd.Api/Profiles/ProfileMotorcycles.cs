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
        
        CreateMap<Rental, ViewRentalDto>();
        CreateMap<CreateRentalDto, Rental>();

        CreateMap<Rental, RentalPriceDto>()
            .ForMember(
                dest => dest.EstimatedTotalValue,
                opt => opt.MapFrom(src => src.GetReturnPrice())
                );

    }
}