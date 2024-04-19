using DesafioBackEnd.Domain.Validators.Motorcycles;

namespace DesafioBackEnd.Domain.Entities.Motorcycles;

public class Motorcycle : EntityBase
{
    public Motorcycle(string model, int year, string licencePlate)
        : base()
    {
        Model = model;
        Year = year;
        LicencePlate = licencePlate;
    }

    public string Model { get; private set; }
    public int Year { get; private set; }
    public string LicencePlate { get; private set; }

    public override bool IsValid()
    {
        var validator = new MotorcycleValidator();

        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }
}