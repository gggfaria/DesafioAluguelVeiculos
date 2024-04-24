using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Response;

namespace DesafioBackEnd.Service.Interfaces.Motorcycles;

public interface IRentalService
{
    Task<ResultService> RentMotorcycle(CreateRentalDto dto);
}