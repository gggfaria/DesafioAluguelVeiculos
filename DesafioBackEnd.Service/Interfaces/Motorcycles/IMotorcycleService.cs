using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Response;

namespace DesafioBackEnd.Service.Interfaces.Motorcycles;

public interface IMotorcycleService
{
    Task<ResultService> CreateMotorcycle(CreateMotorcycleDto dto);
    Task<ResultService> GetByLincence(string licencePlate);
    Task<ResultService> GetAll();
    Task<ResultService> UpdateLicencePlate(Guid motorcycleId, string licencePlate);
    Task<ResultService> Delete(Guid motorcycleId);
}