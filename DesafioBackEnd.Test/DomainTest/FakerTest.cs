using Bogus;
using Bogus.Extensions.Brazil;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Entities.ValueObjects;
using DesafioBackEnd.Domain.Enums;

namespace DesafioBackEnd.Test.DomainTest;

public static class FakerTest
{
    public static Driver CreateDriverFakeValid()
    {
        var cnhType = new Faker().PickRandom(ECnhType.AB, ECnhType.B, ECnhType.A);
        var driver = new Faker<Driver>(locale: "pt_BR")
            .CustomInstantiator(f => new Driver(
                f.Name.FullName(),
                f.Name.FirstName(),
                f.Lorem.Word(),
                new CNPJ(f.Company.Cnpj()),
                f.Date.Past(),
                f.Lorem.Word(), 
                cnhType,
                f.Image.Locale,
                "DRIVER"
            ));

        return driver;
    }
    
    public static Driver CreateDriverFakeCNPJInvalid()
    {
        var cnhType = new Faker().PickRandom(ECnhType.AB, ECnhType.B, ECnhType.A);
        var driver = new Faker<Driver>(locale: "pt_BR")
            .CustomInstantiator(f => new Driver(
                f.Name.FullName(),
                f.Name.FirstName(),
                f.Lorem.Word(),
                new CNPJ(f.Random.Number(15).ToString()),
                f.Date.Past(),
                f.Lorem.Word(), 
                cnhType,
                f.Image.Locale,
                "DRIVER"
            ));

        return driver;
    }

}