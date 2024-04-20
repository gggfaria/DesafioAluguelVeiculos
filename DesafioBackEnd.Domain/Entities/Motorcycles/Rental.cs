using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Validators.Motorcycles;

namespace DesafioBackEnd.Domain.Entities.Motorcycles;

public class Rental : EntityBase
{
    public Rental(Guid motorcycleId,  Guid planId, Guid driverId, DateOnly estimatedDate, DateTime endDate)
    {
        var creationDate = DateTime.UtcNow;
        MotorcycleId = motorcycleId;
        PlanId = planId;
        DriverId = driverId;
        CreationDate = creationDate;
        StartDate = DateOnly.FromDateTime(creationDate.Date.AddDays(1));
        EstimatedDate = estimatedDate;
        EndDate = endDate;
    }

    public Guid MotorcycleId { get; set; }
    public Motorcycle Motorcycle { get; private set; }
    public Guid PlanId { get; private set; }
    public Plan Plan { get; private set; }
    
    public Guid DriverId { get; private set; }
    public Driver Driver { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EstimatedDate { get; private set; }
    public DateTime EndDate { get; private set; }


    public bool HasValidCnh(Driver driver)
    {
        return driver?.Id == DriverId && driver.HasCnhTypeA();
    }
    
    public override bool IsValid()
    {
        var validator = new RentalValidator();

        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }
    
}