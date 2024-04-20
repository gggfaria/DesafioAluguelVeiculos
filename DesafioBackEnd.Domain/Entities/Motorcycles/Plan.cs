using DesafioBackEnd.Domain.Validators.Motorcycles;

namespace DesafioBackEnd.Domain.Entities.Motorcycles;

public class Plan : EntityBase
{
    public int Days { get; private set; }
    public decimal Price { get; private set; }

    public override bool IsValid()
    {
        var validator = new PlanValidator();

        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }
}