namespace DesafioBackEnd.Domain.Entities;

public class InjectionStrings
{
    public string Token { get; set; }
    public string DbConnection { get; set; }

    public InjectionStrings(string token, string dbConnection)
    {
        Token = token;
        DbConnection = dbConnection;
    }
}