using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Interfaces.People;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LoginDto login)
    {
        var resultService = await _authService.Login(login);
        return StatusCode(resultService.StatusCode, resultService);
    }
}