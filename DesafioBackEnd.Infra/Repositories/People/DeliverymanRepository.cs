using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.People;

public class DeliverymanRepository : RepositoryBase<Deliveryman>
{
    public DeliverymanRepository(DesafioContext context) : base(context)
    {
    }
}