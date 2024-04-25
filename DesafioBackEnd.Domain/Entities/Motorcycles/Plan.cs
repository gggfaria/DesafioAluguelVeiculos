using DesafioBackEnd.Domain.Validators.Motorcycles;

namespace DesafioBackEnd.Domain.Entities.Motorcycles;

public class Plan : EntityBase
{
    protected Plan(int fineValue)
    {
        FineValue = fineValue;
    }
    public Plan(int days, decimal price, int? fineValue)
    {
        Days = days;
        Price = price;
        FineValue = fineValue;
        Rentals = new List<Rental>();
    }

    public int Days { get; private set; }
    public decimal Price { get; private set; }
    public int? FineValue { get; private set; }
    public ICollection<Rental> Rentals { get; private set; }
    public override bool IsValid()
    {
        var validator = new PlanValidator();

        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }
}