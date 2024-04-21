using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DesafioBackEnd.Domain.Entities;
using DesafioBackEnd.Domain.Entities.Extensions;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Interfaces.People;
using DesafioBackEnd.Service.Response;
using Microsoft.IdentityModel.Tokens;

namespace DesafioBackEnd.Service.Services.People;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly string? _chaveJwt;

    public AuthService(InjectionStrings tokenInjection, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _chaveJwt = tokenInjection.Token;
    }

    public async Task<ResultService> Login(LoginDto login)
    {
        var user = (await _unitOfWork.Person.FindAsync(p => p.UserName == login.UserName)).FirstOrDefault();

        if (!await IsValidLogin(login, user))
            return ResultServiceFactory.Unauthorized(message: "User or password is invalid");
        
        var token = await CreateToken(login, user);
        
        return ResultServiceFactory<string>.Ok(token, message: "Token created with success");

    }
    

    private async Task<bool> IsValidLogin(LoginDto login,  Person user)
    {
        return user?.Password == login.Password.CreateHash();
    }

    private async Task<string> CreateToken(LoginDto loginDTO, Person user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_chaveJwt);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("PersonName", user.Name),
                new Claim(ClaimTypes.Role, user.Permission),
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}