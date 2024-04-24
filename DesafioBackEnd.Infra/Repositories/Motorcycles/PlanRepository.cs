using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Repositories.Motorcycles;

public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
{
    public PlanRepository(DesafioContext context) : base(context)
    {
    }
    
    public async Task<Plan?> GetRentalByDays(int days)
    {
        IQueryable<Plan> query = _context.Set<Plan>().AsQueryable();

        return await query.Where(p => days <= p.Days)
            .OrderBy(p => p.Days)
            .FirstOrDefaultAsync();
    }
}