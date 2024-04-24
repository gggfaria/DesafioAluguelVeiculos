using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Response;
using Microsoft.AspNetCore.Http;

namespace DesafioBackEnd.Service.Interfaces.People;

public interface IDriverService
{
    Task<ResultService> CreateDriver(CreateDriverDto dto);
    Task<ResultService> UploadImage(IFormFile cnhImage);
}