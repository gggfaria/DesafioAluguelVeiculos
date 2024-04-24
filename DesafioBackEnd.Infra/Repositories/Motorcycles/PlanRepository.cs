using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.Motorcycles;

public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
{
    public PlanRepository(DesafioContext context) : base(context)
    {
    }
}