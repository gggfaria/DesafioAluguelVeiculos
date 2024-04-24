using System.ComponentModel.DataAnnotations;
using DesafioBackEnd.Domain.Enums;

namespace DesafioBackEnd.Service.DTOs.People;

public class CreateDriverDto
{
    [Required]
    public string Name { get;  set; }
    
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Cnpj { get;  set; }

    [Required]
    public DateTime DateOfBirth { get;  set; }
    
    [Required]
    public string CnhNumber { get;  set; }
    
    [Required]
    public ECnhType CnhType { get;  set; }
    
    [Required]
    public string CnhImage { get;  set; }
    

}