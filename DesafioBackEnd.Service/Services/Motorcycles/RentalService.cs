using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Service.Interfaces.Motorcycles;

namespace DesafioBackEnd.Service.Services.Motorcycles;

public class RentalService : IRentalService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public RentalService()
    {
        
    }
    
    
}