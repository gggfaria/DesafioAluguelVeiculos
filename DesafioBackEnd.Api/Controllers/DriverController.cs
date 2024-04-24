using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Interfaces.People;
using DesafioBackEnd.Service.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(ViewDriverDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResultService), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateDriverDto dto)
    {
        ResultService result = await _driverService.CreateDriver(dto);
        
        return StatusCode(result.StatusCode, result);
    }
    
        
    [HttpPost("Uploadimage")]
    [Authorize(Roles = "DRIVER")]
    [ProducesResponseType(typeof(ViewDriverDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResultService), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(IFormFile imageCnh)
    {
        var result = await _driverService.UploadImage(imageCnh);
        return StatusCode(result.StatusCode, result);
    }
    
}