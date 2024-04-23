using DesafioBackEnd.Domain.Entities.Motorcycles;

namespace DesafioBackEnd.Domain.Repositories.Motorcycles;

public interface IMotorcycleRepository : IRepositoryBase<Motorcycle>
{
    Task<Motorcycle?> GetByLicencePlate(string licence);
}