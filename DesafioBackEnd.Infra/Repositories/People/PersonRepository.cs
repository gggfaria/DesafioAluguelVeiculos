using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Repositories.People;
using DesafioBackEnd.Infra.Context;

namespace DesafioBackEnd.Infra.Repositories.People;

public class PersonRepository : RepositoryBase<Person>, IPersonRepository 
{
    public PersonRepository(DesafioContext context) : base(context)
    {
    }
}