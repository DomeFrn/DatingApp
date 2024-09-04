using API.Extensions;

namespace API.Models;

public class AppUser
{
    public int Id { get; set; }
    public required string Username { get; set; } 
    public byte[]? PasswortHash {get; set;}
    public byte[]? PasswortSalt {get; set;}
    public DateOnly Geburtsdatum {get; set;}
    public required string BekanntAls {get; set;}
    public DateTime ErstelltAm {get; set;} = DateTime.UtcNow;
    public DateTime ZuletztAktiv {get; set;} = DateTime.UtcNow;
    public required string Geschlecht {get; set;}
    public string? Vorstellung {get; set;}
    public string? Interessen {get; set;}
    public string? SuchtNach {get; set;}
    public required string Stadt {get; set;}
    public required string Land {get; set;}
    public List<Foto> Fotos {get; set;} = []; 
}
