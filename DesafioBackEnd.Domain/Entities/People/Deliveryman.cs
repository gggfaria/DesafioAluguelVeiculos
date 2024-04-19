using DesafioBackEnd.Domain.Entities.Extensions;
using DesafioBackEnd.Domain.Entities.ValueObjects;
using DesafioBackEnd.Domain.Enums;
using DesafioBackEnd.Domain.Validators.People;
using DesafioBackEnd.Domain.Validators.ValueObjects;

namespace DesafioBackEnd.Domain.Entities.People;

public class Deliveryman : Person
{
    public Deliveryman(string name, string userName, string password, CNPJ cnpj, DateTime dateOfBirth, string cnhNumber, ECnhType cnhType, string cnhImage) :
        base(name, userName, password)
    {
        Cnpj = cnpj;
        DateOfBirth = dateOfBirth;
        CnhNumber = cnhNumber;
        CnhType = cnhType;
        CnhImage = cnhImage;
    }

    public CNPJ Cnpj { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string CnhNumber { get; private set; }
    public ECnhType CnhType { get; set; }
    public string CnhImage { get; set; }

    
    public override bool IsValid()
    {
        base.IsValid();

        var deliverymanValidator = new DeliverymanValidator();
        var cnpjValidator = new CNPJValidator();
        
        var resultDeliverymanValidator = deliverymanValidator.Validate(this);
        var resultcnpjValidator = cnpjValidator.Validate(Cnpj);
        
        if (!resultDeliverymanValidator.IsValid)
            ValidationResultData.AddErrors(resultDeliverymanValidator);
        if(!resultcnpjValidator.IsValid)
            ValidationResultData.AddErrors(resultcnpjValidator);


        return ValidationResultData.IsValid;
    }
    
    
}