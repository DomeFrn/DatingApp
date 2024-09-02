using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if (await context.Users.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        Console.WriteLine("Data Eingelesen zum Seeden");

        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

        if (users == null) return;
           
        Console.WriteLine("Die Schleife beginnt gleich");
        
        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();
            user.Username = user.Username.ToLower();
            user.PasswortHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
            user.PasswortSalt = hmac.Key;

            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
        Console.WriteLine("Seeding Erfolgreich!");
    }
}
