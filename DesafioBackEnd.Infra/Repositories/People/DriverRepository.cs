using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.People;

public class DriverRepository : RepositoryBase<Driver>
{
    public DriverRepository(DesafioContext context) : base(context)
    {
    }
}