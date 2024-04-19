using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra;

public class UnitOfWork : IUnitOfWork
{
    protected readonly DesafioContext _context;
    private IInstituicaoRepository _instituicoes;

    public UnitOfWork(DesafioContext context)
    {
        _context = context;
    }

    public IInstituicaoRepository Instituicoes
    {
        get { return _instituicoes ??= new InstituicaoRepository(_context); }
    }


    public bool Commit() => _context.SaveChanges() > 0;

    public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;      

    public void Dispose()
    {
        _context.Dispose();
    }
}