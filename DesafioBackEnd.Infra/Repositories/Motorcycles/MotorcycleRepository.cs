using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.Motorcycles;

public class MotorcycleRepository : RepositoryBase<Motorcycle>, IMotorcycleRepository
{
    public MotorcycleRepository(DesafioContext context) : base(context)
    {
    }
}