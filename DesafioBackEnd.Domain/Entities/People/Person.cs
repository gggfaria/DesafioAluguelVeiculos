using DesafioBackEnd.Domain.Validators.People;

namespace DesafioBackEnd.Domain.Entities.People;

public abstract class Person : EntityBase
{
    public static readonly HashSet<string> PERMISSIONS = new HashSet<string> { "ADMIN", "DRIVER" };

    protected Person(string name, string userName, string password, string type)
    {
        Name = name;
        UserName = userName;
        Password = password;
        Type = type;
    }

    public string Name { get; protected set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Type { get; private set; }
    
    private string _permission;

    public string Permission
    {
        get { return _permission; }
        set
        {
            if (PERMISSIONS.Contains(value))
                _permission = value;
            else
                throw new ArgumentException("Permission is not valid");
        }
    }
    
    public override bool IsValid()
    {
        var validator = new PersonValidator();

        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }
}