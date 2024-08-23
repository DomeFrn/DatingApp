namespace API.Models;

public class AppUser
{
    public int Id { get; set; }
    public required string Username { get; set; } 
    public required byte[] PasswortHash {get; set;}
    public required byte[] PasswortSalt {get; set;}
    
}