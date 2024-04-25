using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Interfaces.Motorcycles;
using DesafioBackEnd.Service.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public RentalController(IRentalService rentalService, IHttpContextAccessor httpContextAccessor)
    {
        _rentalService = rentalService;
        _httpContextAccessor = httpContextAccessor;
    }


    [HttpPost]
    [Authorize(Roles = "DRIVER")]
    [ProducesResponseType(typeof(ViewRentalDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResultService), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateRentalDto dto)
    {
        dto.SetDriverFromAuth(GetUserIdByTokenAuth());
        ResultService result = await _rentalService.RentMotorcycle(dto);
        
        return StatusCode(result.StatusCode, result);
    }


    private Guid GetUserIdByTokenAuth()
    {
        var user = _httpContextAccessor.HttpContext!.User;
        var userId = user.FindFirst("Id")!.Value;
        return new Guid(userId);
    }
}