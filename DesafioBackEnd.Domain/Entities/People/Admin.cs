namespace DesafioBackEnd.Domain.Entities.People;

public class Admin : Person
{
    public Admin(string name, string userName, string password, string permission) : base(name, userName, password, permission)
    {
    }

    protected Admin()
    {
    }
}