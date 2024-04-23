using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Repositories.Motorcycles;

public class MotorcycleRepository : RepositoryBase<Motorcycle>, IMotorcycleRepository
{
    public MotorcycleRepository(DesafioContext context) : base(context)
    {
    }
    
    public async Task<Motorcycle> GetByLicencePlate(string licence)
    {
        IQueryable<Motorcycle> query = _context.Set<Motorcycle>().AsQueryable();

        return await query.SingleOrDefaultAsync(e => e.LicencePlate.Equals(licence));
    }
    
    public async Task<Motorcycle?> GetByIdWithRentals(Guid id)
    {
        IQueryable<Motorcycle> query =
            _context.Set<Motorcycle>()
            .Include(p => p.Rentals)
            .AsQueryable();

        return await query.SingleOrDefaultAsync(e => e.Id.Equals(id));
    }

}