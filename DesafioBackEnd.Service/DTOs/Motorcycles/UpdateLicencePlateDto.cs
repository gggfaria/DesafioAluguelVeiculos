using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Service.DTOs.Motorcycles;

public class UpdateLicencePlateDto
{
    [Required]
    public string LicencePlate { get; set; }
}