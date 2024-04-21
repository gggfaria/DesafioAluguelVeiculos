namespace DesafioBackEnd.Domain.Entities.People;

public class Admin : Person
{
    public Admin(string name, string userName, string password, string type) : base(name, userName, password, type)
    {
    }
}