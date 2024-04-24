using DesafioBackEnd.Domain.Entities.Extensions;
using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Entities.ValueObjects;
using DesafioBackEnd.Domain.Enums;
using DesafioBackEnd.Domain.Validators.People;

namespace DesafioBackEnd.Domain.Entities.People;

public class Driver : Person
{
    protected Driver()
    {
        Permission = "DRIVER";

    }

    public Driver(string name, string userName, string password, CNPJ cnpj, DateTime dateOfBirth, string cnhNumber,
        ECnhType cnhType, string cnhImage) :
        base(name, userName, password)
    {
        Cnpj = cnpj;
        DateOfBirth = dateOfBirth;
        CnhNumber = cnhNumber;
        CnhType = cnhType;
        CnhImage = cnhImage;
        Permission = "DRIVER";

        Rentals = new List<Rental>();
    }

    public CNPJ Cnpj { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string CnhNumber { get; private set; }
    public ECnhType CnhType { get; private set; }
    public string? CnhImage { get; private set; }   
    public long? ImageSize { get; private set; }
    public string? ImageType { get; private set; }
    
    public const int MAX_SIZE_IMG_BYTES = 10 * 1024 * 1024;
    public static readonly string[] ALLOWED_TYPES_IMG = { "image/png", "image/bmp" };


    public ICollection<Rental> Rentals { get; private set; }

    public bool HasCnhTypeA()
    {
        return CnhType is ECnhType.A or ECnhType.AB;
    }

    public void SetImageUrl(string url)
    {
        CnhImage = url;
    }

    public void SetImageInfo(string url, string type, long size)
    {
        CnhImage = url;
        ImageType = type;
        ImageSize = size;
    }


    public override bool IsValid()
    {
        base.IsValid();

        ValidateCnpj();
        
        var deliverymanValidator = new DriverValidator();

        var resultDeliverymanValidator = deliverymanValidator.Validate(this);

        if (!resultDeliverymanValidator.IsValid)
            ValidationResultData.AddErrors(resultDeliverymanValidator);


        return ValidationResultData.IsValid;
    }

    private void ValidateCnpj()
    {
        if (Cnpj.IsValid()) 
            return;
        
        ValidationResultData.AddErrors(Cnpj.ValidationResultData);
    }
}