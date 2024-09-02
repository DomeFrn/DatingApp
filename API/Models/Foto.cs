using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Fotos")]
public class Foto
{
    public int Id {get; set;}
    public required string Url {get; set;}
    public bool IsMain  {get; set;}
    public string? PublicId {get; set;}

    // Navigation Properties (für Fremdschlüssel)

    public int AppUserId {get; set;}
    public AppUser AppUser {get; set;} = null!;
}