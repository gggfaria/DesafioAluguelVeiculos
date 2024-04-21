using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Response;

namespace DesafioBackEnd.Service.Interfaces.People;

public interface IAuthService
{
    Task<ResultService> Login(LoginDto login);
}