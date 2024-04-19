namespace DesafioBackEnd.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
    Task<bool> CommitAsync();
}