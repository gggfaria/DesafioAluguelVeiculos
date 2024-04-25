using DesafioBackEnd.Domain.Entities.Motorcycles;

namespace DesafioBackEnd.Test.DomainTest.Motorcycles;

public class RentalTest
{
    //AAA Arrange, Act, Assert

    //Nomenclatura 
    //MetodoTestado_EstadoEmTeste_ComportamentoEsperado
    //ObjetoEmTeste_MetodoComportamentoEmTeste_ComportamentoEsperado
    
    

    [Fact]
    [Trait("Category", "Rental")]
    public void Rental_GetReturnPrice_Plan7_LateReturn()
    {
        var rental = FakerTest.CreateRentalEstimatedDate(DateTime.UtcNow.AddDays(6));
        rental.SetPlan(new Plan(7, 30, 20));
        rental.SetEndDate(DateTime.UtcNow.AddDays(7));
        
        var resultFinalValue = rental.GetReturnPrice();
        
        Assert.Equal(230, resultFinalValue);
    }
    
    [Fact]
    [Trait("Category", "Rental")]
    public void Rental_GetReturnPrice_Plan7_EarlyReturn()
    {
        var rental = FakerTest.CreateRentalEstimatedDate(DateTime.UtcNow.AddDays(7));
        rental.SetPlan(new Plan(7, 30, 20));
        rental.SetEndDate(DateTime.UtcNow.AddDays(4));
        
        var resultFinalValue = rental.GetReturnPrice();
        
        Assert.Equal(108, resultFinalValue);
    }
    
    [Fact]
    [Trait("Category", "Rental")]
    public void Rental_GetReturnPrice_Plan15_EarlyReturn()
    {
        var rental = FakerTest.CreateRentalEstimatedDate(DateTime.UtcNow.AddDays(16));
        rental.SetPlan(new Plan(15, 28, 40));
        rental.SetEndDate(DateTime.UtcNow.AddDays(14));
       
        var resultFinalValue = rental.GetReturnPrice();
        
        Assert.Equal(386.4m, resultFinalValue);
    }
    
    [Fact]
    [Trait("Category", "Rental")]
    public void Rental_GetReturnPrice_Plan7_OnDate()
    {
        var rental = FakerTest.CreateRentalEstimatedDate(DateTime.UtcNow.AddDays(7));
        rental.SetPlan(new Plan(7, 30, 20));
        rental.SetEndDate(DateTime.UtcNow.AddDays(7));
        
        var resultFinalValue = rental.GetReturnPrice();
        
        Assert.Equal(180, resultFinalValue);
    }
    
}