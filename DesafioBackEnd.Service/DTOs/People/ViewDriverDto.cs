using DesafioBackEnd.Domain.Enums;

namespace DesafioBackEnd.Service.DTOs.People;

public class ViewDriverDto
{
    public string Name { get; set; }
    
    public Guid Id { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public bool IsActive { get; set; }
    public string Cnpj { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public string CnhNumber { get; private set; }

    public ECnhType CnhType { get; private set; }

    public string CnhImage { get; private set; }
}