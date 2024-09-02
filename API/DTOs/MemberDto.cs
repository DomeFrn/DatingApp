namespace API.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string? Username { get; set; } 
    public int Age {get; set;}
    public string? FotoURL {get; set;}
    public string? BekanntAls {get; set;}
    public DateTime ErstelltAm {get; set;} 
    public DateTime ZuletztAktiv {get; set;}
    public string? Geschlecht {get; set;}
    public string? Vorstellung {get; set;}
    public string? Interessen {get; set;}
    public string? SuchtNach {get; set;}
    public string? Stadt {get; set;}
    public string? Land {get; set;}
    public List<FotoDto>? Fotos {get; set;}
}
