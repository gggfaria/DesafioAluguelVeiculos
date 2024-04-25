using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Repositories.Motorcycles;

public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
{
    public RentalRepository(DesafioContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Rental?>> FindAllActiveFromDriver(Guid driverId)
    {
        return await _context.Set<Rental>()
            .Where(p => p.DriverId == driverId && p.IsActive && p.EndDate == null)
            .Include(p => p.Plan)
            .OrderBy(c => c.CreationDate)
            .ToListAsync();
    }
    
}