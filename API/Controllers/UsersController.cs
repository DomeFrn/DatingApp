using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users (Ist immer durch [controller] der Name vor dem Controller in dem Klassennamen)
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet] // Jeder Controller darf jede HTTP Art nur genau einmal haben
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() // Durch async, können mehrer Anfragen gesendet werden
    {
        var users = await context.Users.ToListAsync(); // Bei Get Users HTTP Anfrage, werden aller nutze als Liste aus dem COntext (der DB) extrahiert

        return users;
    }

    [HttpGet("{id}")] // Anfrage nimm zusätlich id als Argument entgegen => /api/users/id, Argument wird in der Anfrage verwendet
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound(); // fängt ab, wenn zu der id kein User gefunden wurde

        return user;
    }
}