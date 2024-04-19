using DesafioBackEnd.Domain.Validators.People;

namespace DesafioBackEnd.Domain.Entities.People;

public abstract class Person : EntityBase
{
    protected Person(string name, string userName, string password)
    {
        Name = name;
        UserName = userName;
        Password = password;
    }

    public string Name { get; protected set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public override bool IsValid()
    {
        var validator = new PersonValidator();

        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }
}