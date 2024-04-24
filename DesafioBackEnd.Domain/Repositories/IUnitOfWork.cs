using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Domain.Repositories.People;

namespace DesafioBackEnd.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
    Task<bool> CommitAsync();

    IPersonRepository Person { get;  }
    IMotorcycleRepository Motorcycle { get;  }
    IDriverRepository Driver { get;  }
    
}