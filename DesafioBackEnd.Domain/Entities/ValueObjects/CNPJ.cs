using DesafioBackEnd.Domain.Entities.Extensions;
using DesafioBackEnd.Domain.Validators.ValueObjects;

namespace DesafioBackEnd.Domain.Entities.ValueObjects;

public class CNPJ : ValueObject
{
    protected CNPJ()
    {
    }

    public CNPJ(string number)
    {
        Number = number.GetNumbers();
    }

    public string Number { get; private set; }

    public override bool IsValid()
    {
        var validator = new CNPJValidator();
        ValidationResultData = validator.Validate(this);

        return ValidationResultData.IsValid;
    }

    #region Overrides

    public override string ToString()
    {
        if (!int.TryParse(Number, out int numeroConvertido) || !ValidationResultData.IsValid)
            return this.Number;

        return numeroConvertido.ToString("##\\.###\\.###/####-##").PadLeft(18, '0');
    }

    public override bool Equals(object obj)
    {
        var compareTo = obj as CNPJ;

        if (ReferenceEquals(this, compareTo)) return true;
        if (compareTo is null) return false;

        return this.Number.Equals(compareTo.Number);
    }

    public static bool operator ==(CNPJ a, CNPJ b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(CNPJ a, CNPJ b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Number.GetHashCode();
    }

    #endregion
}