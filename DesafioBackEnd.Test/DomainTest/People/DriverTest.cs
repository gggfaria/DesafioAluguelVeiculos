namespace DesafioBackEnd.Test.DomainTest.People;

public class DriverTest
{
    
    //AAA Arrange, Act, Assert

    //Nomenclatura 
    //MetodoTestado_EstadoEmTeste_ComportamentoEsperado
    //ObjetoEmTeste_MetodoComportamentoEmTeste_ComportamentoEsperado
    
    public DriverTest()
    {

    }

    [Fact]
    [Trait("Category", "Driver")]
    public void Driver_CreateDriver_Valid()
    {
        var driver = FakerTest.CreateDriverFakeValid();

        var result = driver.IsValid();
        Assert.True(result, "Driver is invalid");
    }
    
    [Fact]
    [Trait("Category", "Driver")]
    public void Driver_CreateDriver_Invalid()
    {
        var driver = FakerTest.CreateDriverFakeCNPJInvalid();

        var result = driver.IsValid();
        var errors =  driver.ValidationResultData.Errors;
        var hasCnpjInvalid = errors.Any(p => p.ErrorMessage.Equals("CNPJ invalid"));
        Assert.True(hasCnpjInvalid, "CNPJ validation error");
    }
}