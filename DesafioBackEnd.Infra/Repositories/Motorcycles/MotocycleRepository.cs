using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.Motorcycles;

public class MotocycleRepository : RepositoryBase<Motorcycle>
{
    public MotocycleRepository(DesafioContext context) : base(context)
    {
    }
}