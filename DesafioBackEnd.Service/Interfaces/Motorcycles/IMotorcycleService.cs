using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Response;

namespace DesafioBackEnd.Service.Interfaces.Motorcycles;

public interface IMotorcycleService
{
    Task<ResultService> CreateMotorcycle(CreateMotorcycleDto dto);
}