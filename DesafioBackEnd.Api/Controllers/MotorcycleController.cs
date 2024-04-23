using DesafioBackEnd.Service.DTOs.Motorcycles;
using DesafioBackEnd.Service.Interfaces.Motorcycles;
using DesafioBackEnd.Service.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "ADMIN")]
public class MotorcycleController : ControllerBase
{
    private readonly IMotorcycleService _motorcycleService;
    
    public MotorcycleController(IMotorcycleService motorcycleService)
    {
        _motorcycleService = motorcycleService;
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(ViewMotorcycleDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResultService), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateMotorcycleDto dto)
    {
        ResultService result = await _motorcycleService.CreateMotorcycle(dto);
        
        return StatusCode(result.StatusCode, result);
    }
}