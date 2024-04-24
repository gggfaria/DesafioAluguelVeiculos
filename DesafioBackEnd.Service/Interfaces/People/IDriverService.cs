using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Response;

namespace DesafioBackEnd.Service.Interfaces.People;

public interface IDriverService
{
    Task<ResultService> CreateDriver(CreateDriverDto dto);
}