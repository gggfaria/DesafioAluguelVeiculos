namespace DesafioBackEnd.Service.DTOs.Motorcycles;

public class ViewMotorcycleDto
{
    
    public Guid Id { get; protected set; }
    public DateTime CreationDate { get; protected set; }
    public bool IsActive { get; protected set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public string LicencePlate { get; private set; }

}