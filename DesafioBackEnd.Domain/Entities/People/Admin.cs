namespace DesafioBackEnd.Domain.Entities.People;

public class Admin : Person
{
    public Admin(string name, string userName, string password) : base(name, userName, password)
    {
        Permission = "ADMIN";
    }

    protected Admin()
    {
    }
}