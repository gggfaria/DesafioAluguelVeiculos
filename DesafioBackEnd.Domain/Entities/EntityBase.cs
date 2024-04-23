using DesafioBackEnd.Domain.Entities.Extensions;
using FluentValidation.Results;

namespace DesafioBackEnd.Domain.Entities;

public abstract class EntityBase
{
    protected EntityBase()
    {
        Id = Guid.NewGuid();
        IsActive = true;
        ValidationResultData = new ValidationResult();
    }

    public Guid Id { get; protected set; }
    public DateTime CreationDate { get; protected set; }
    public bool IsActive { get; protected set; }
    
    public ValidationResult ValidationResultData { get; protected set; }
    
    public abstract bool IsValid();
    
    public ICollection<InvalidDataResult> GetInvalidData()
    {
        return ValidationResultData.GetErrorsResult();
    }
    
    public virtual void Active()
    {
        IsActive = true;
    }
    
    public virtual void Disable()
    {
        IsActive = false;
    }
    
    public override bool Equals(object obj)
    {
        var compareTo = obj as EntityBase;

        if (ReferenceEquals(this, compareTo)) return true;
        if (compareTo is null) return false;

        return this.Id.Equals(compareTo.Id);
    }
    
    public static bool operator ==(EntityBase a, EntityBase b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }
    
    public static bool operator !=(EntityBase a, EntityBase b)
    {
        return !(a == b);
    }
    
    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id = {Id}]";
    }


}