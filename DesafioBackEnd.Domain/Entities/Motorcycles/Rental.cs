using DesafioBackEnd.Domain.Entities.Extensions;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Validators.Motorcycles;
using FluentValidation.Results;

namespace DesafioBackEnd.Domain.Entities.Motorcycles;

public class Rental : EntityBase
{
    protected Rental()
    {
        var creationDate = DateTime.UtcNow;
        CreationDate = creationDate;
        StartDate = creationDate.Date.AddDays(1);
    }
    
    public Rental(Guid motorcycleId,  Guid planId, Guid driverId, DateTime estimatedDate, DateTime endDate)
    {
        var creationDate = DateTime.UtcNow;
        MotorcycleId = motorcycleId;
        PlanId = planId;
        DriverId = driverId;
        CreationDate = creationDate;
        StartDate = creationDate.Date.AddDays(1);
        EstimatedDate = estimatedDate;
        EndDate = endDate;
    }

    public Guid MotorcycleId { get; private set; }
    public Motorcycle Motorcycle { get; private set; }
    public Guid PlanId { get; private set; }
    public Plan Plan { get; private set; }
    
    public Guid DriverId { get; private set; }
    public Driver Driver { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EstimatedDate { get; private set; }
    public DateTime? EndDate { get; private set; }


    public int GetAmountDays()
    {
        TimeSpan diference = EstimatedDate.Subtract(StartDate);
        return diference.Days;
    }

    public void SetPlanId(Guid id)
    {
        PlanId = id;
    }
    
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
    
    public bool IsValid(Driver driver)
    {
        var validator = new RentalValidator();
        ValidationResultData = validator.Validate(this);
        
        if(!HasValidCnh(driver))
            ValidationResultData.AddError(new ValidationFailure("Driver", "Licence type must be A"));
        
        return ValidationResultData.IsValid;
    }
}