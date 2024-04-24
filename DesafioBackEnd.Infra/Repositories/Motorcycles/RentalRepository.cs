using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Domain.Repositories.Motorcycles;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.Motorcycles;

public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
{
    public RentalRepository(DesafioContext context) : base(context)
    {
    }
}