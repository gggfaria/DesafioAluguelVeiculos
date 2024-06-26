using Bogus;
using Bogus.Extensions.Brazil;
using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Entities.ValueObjects;
using DesafioBackEnd.Domain.Enums;

namespace DesafioBackEnd.Test.DomainTest;

public static class FakerTest
{
    static FakerTest()
    {
    }

    public static Driver CreateDriverFakeValid()
    {
        var cnhType = new Faker().PickRandom(ECnhType.AB, ECnhType.B, ECnhType.A);
        var driver = new Faker<Driver>(locale: "pt_BR")
            .CustomInstantiator(f => new Driver(
                name: f.Name.FullName(),
                userName: f.Name.FirstName(),
                password: f.Lorem.Word(),
                cnpj: new CNPJ(f.Company.Cnpj()),
                dateOfBirth: f.Date.Past(),
                cnhNumber: f.Lorem.Word(),
                cnhType: cnhType,
                cnhImage: f.Image.Locale
            ));

        return driver;
    }

    public static Driver CreateDriverFakeCNPJInvalid()
    {
        var cnhType = new Faker().PickRandom(ECnhType.AB, ECnhType.B, ECnhType.A);
        var driver = new Faker<Driver>(locale: "pt_BR")
            .CustomInstantiator(f => new Driver(
                name: f.Name.FullName(),
                userName: f.Name.FirstName(),
                password: f.Lorem.Word(),
                cnpj: new CNPJ(f.Random.Number(15).ToString()),
                dateOfBirth: f.Date.Past(),
                cnhNumber: f.Lorem.Word(),
                cnhType: cnhType,
                cnhImage: f.Image.Locale
            ));

        return driver;
    }
    
    public static Rental CreateRentalEstimatedDate(DateTime estimatedDate)
    {
        var rental = new Rental(
            motorcycleId: Guid.NewGuid(),
            planId: Guid.NewGuid(),
            driverId: Guid.NewGuid(),
            estimatedDate: estimatedDate,
            endDate: null
        );

        return rental;
    }
    
    
}