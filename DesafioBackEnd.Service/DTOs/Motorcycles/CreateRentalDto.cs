using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;

namespace DesafioBackEnd.Service.DTOs.Motorcycles;

public class CreateRentalDto
{
    [Required] 
    public Guid MotorcycleId { get; set; }
    
    [Required]
    public DateTime EstimatedDate { get; set; }
    
    [Ignore]
    public Guid DriverId { get; private set; }

    public void SetDriverFromAuth(Guid driverId)
    {
        DriverId = driverId;
    }
    
}