using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Repositories.People;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.People;

public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
{
    public DriverRepository(DesafioContext context) : base(context)
    {
    }
}