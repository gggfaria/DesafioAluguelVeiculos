namespace DesafioBackEnd.Domain.Entities;

public class InvalidDataResult
{
    public InvalidDataResult(string entity, string message)
    {
        Entity = entity;
        Message = message;
    }

    public string Entity { get; set; }
    public string Message { get; set; }
}