using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Infra.Context;
using DesafioBackEnd.Infra.Repositories.Motorcycles;

namespace DesafioBackEnd.Infra;

public class UnitOfWork : IUnitOfWork
{
    protected readonly DesafioContext _context;
    private IMotorcycleRepository _motorcycleRepository;

    public UnitOfWork(DesafioContext context)
    {
        _context = context;
    }

    public IMotorcycleRepository Motorcycle
    {
        get { return _motorcycleRepository ??= new MotorcycleRepository(_context); }
    }


    public bool Commit() => _context.SaveChanges() > 0;

    public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;      

    public void Dispose()
    {
        _context.Dispose();
    }
}