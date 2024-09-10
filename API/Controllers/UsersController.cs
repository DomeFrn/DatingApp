using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Interface;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// /api/users (Ist immer durch [controller] der Name vor dem Controller in dem Klassennamen)

[Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{
    [HttpGet] // Jeder Controller darf jede HTTP Art nur genau einmal haben
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() // Durch async, können mehrer Anfragen gesendet werden
    {
        var users = await userRepository.GetMembersAsync(); // Bei Get Users HTTP Anfrage, werden aller nutze als Liste aus dem COntext (der DB) extrahiert, unktion dafür in dem repo

        return Ok(users);
    }

    [HttpGet("{username}")] // Anfrage nimm zusätlich id als Argument entgegen => /api/users/id, Argument wird in der Anfrage verwendet
    public async Task<ActionResult<MemberDto>> GetUsers(string username)
    {
        var user = await userRepository.GetMemberAsync(username);

        if (user == null) return NotFound(); // fängt ab, wenn zu der id kein User gefunden wurde

        return user;
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto) 
    {
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (username == null) return BadRequest("Kein Username gefunden");

        var user = await userRepository.GetUserByUsernameAsync(username);

        if (user == null) return  BadRequest("Kein User gefunden");

        mapper.Map(memberUpdateDto, user);

        if (await userRepository.SaveAllAsync())
        {
            return NoContent();
        } 

        return BadRequest("Nutzer Update Fehlgeschlagen");
    }
}