using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Service.DTOs.Motorcycles;

public class CreateMotorcycleDto
{
    [Required]
    public string Model { get;  set; }
    
    [Required]
    public int Year { get;  set; }
    
    [Required]
    public string LicencePlate { get;  set; }
}