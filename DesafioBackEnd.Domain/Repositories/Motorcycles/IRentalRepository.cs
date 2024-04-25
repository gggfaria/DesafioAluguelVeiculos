using DesafioBackEnd.Domain.Entities.Motorcycles;

namespace DesafioBackEnd.Domain.Repositories.Motorcycles;

public interface IRentalRepository : IRepositoryBase<Rental>
{
    Task<IEnumerable<Rental?>> FindAllActiveFromDriver(Guid driverId);
}