namespace DesafioBackEnd.Service.DTOs.Motorcycles;

public class ViewRentalDto
{
    
    public Guid MotorcycleId { get;  set; }
    
    public Guid PlanId { get;  set; }
    
    public Guid DriverId { get;  set; }
    
    public DateTime StartDate { get;  set; }
    
    public DateTime EstimatedDate { get;  set; }
}