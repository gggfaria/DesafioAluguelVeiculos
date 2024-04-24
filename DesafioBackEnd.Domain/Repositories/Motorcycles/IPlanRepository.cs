using DesafioBackEnd.Domain.Entities.Motorcycles;

namespace DesafioBackEnd.Domain.Repositories.Motorcycles;

public interface IPlanRepository : IRepositoryBase<Plan>
{
    Task<Plan?> GetRentalByDays(int days);
}