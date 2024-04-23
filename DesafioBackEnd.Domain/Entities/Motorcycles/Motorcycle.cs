using DesafioBackEnd.Domain.Validators.Motorcycles;

namespace DesafioBackEnd.Domain.Entities.Motorcycles;

public class Motorcycle : EntityBase
{
    protected Motorcycle()
    {
        
    }
    public Motorcycle(string model, int year, string licencePlate)
    {
        Model = model;
        Year = year;
        LicencePlate = licencePlate;

        Rentals = new List<Rental>();
    }

    public ICollection<Rental> Rentals { get; private set; } 
    public string Model { get; private set; }
    public int Year { get; private set; }
    public string LicencePlate { get; private set; }

    public void UpdateLicence(string licencePlate)
    {
        LicencePlate = licencePlate;
    }

    public override bool IsValid()
    {
        var validator = new MotorcycleValidator();

        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }
}