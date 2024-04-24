using DesafioBackEnd.Domain.Entities.Extensions;
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

    public static readonly HashSet<string> PERMISSIONS = new HashSet<string> { "ADMIN", "DRIVER" };

    protected Person()
    {
        
    }
    

    public string Name { get; protected set; }
    public string UserName { get; protected set; }

    private string _password;
    public string Password {
        get { return _password; }
        set
        {
            _password = value.CreateHash();
            
        }
    }
    
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