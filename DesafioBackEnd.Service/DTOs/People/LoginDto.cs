using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Service.DTOs.People;

public class LoginDto
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
}