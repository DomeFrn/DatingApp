using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")] // account/register
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return BadRequest("Nutzername bereits vergeben");

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            Username = registerDto.Username.ToLower(),
            PasswortHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswortSalt = hmac.Key
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return new UserDto
        {
            Username = user.Username,
            Token = tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")] //Http  Request für Anmeldung
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Username == loginDto.Username.ToLower()); // Sucht ob eingegebener Nutzer in DB existiert

        if (user == null) return Unauthorized("Ungültiger Nutzername");

        using var hmac = new HMACSHA512(user.PasswortSalt); // erzeugt Hash aus eigegeben Passwort 

        var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password)); 

        for (int i = 0; i < ComputedHash.Length; i++) //vergleicht jeden Byte des Hashes mit dem eigegben Hash
        {
            if (ComputedHash[i] != user.PasswortHash[i]) return Unauthorized("Ungültiges Passwort");
        }

         return new UserDto
        {
            Username = user.Username,
            Token = tokenService.CreateToken(user)
        };
    }

    // Methode zum Prüfen auf Doppelte Passwörter
    private async Task<bool> UserExists(string Username)
    {
        return await context.Users.AnyAsync(x => x.Username.ToLower() == Username.ToLower()); 
    }
    
}
