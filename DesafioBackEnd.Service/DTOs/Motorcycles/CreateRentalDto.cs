using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;

namespace DesafioBackEnd.Service.DTOs.Motorcycles;

public class CreateRentalDto
{
    [Ignore] 
    public Guid MotorcycleId { get; set; }
    
    [Required]
    public Guid DriverId { get; set; }
    
    [Required]
    public DateTime EstimatedDate { get; set; }
    
}