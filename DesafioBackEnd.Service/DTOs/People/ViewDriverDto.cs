using DesafioBackEnd.Domain.Enums;

namespace DesafioBackEnd.Service.DTOs.People;

public class ViewDriverDto
{
    public string Name { get; set; }
    
    public Guid Id { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public bool IsActive { get; set; }
    public string Cnpj { get;  set; }

    public DateTime DateOfBirth { get;  set; }

    public string CnhNumber { get;  set; }

    public ECnhType CnhType { get;  set; }

    public string CnhImage { get;  set; }

    public string TokenJwt { get; set; }
}