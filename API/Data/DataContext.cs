using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; } // User wird Name der Tabelle in der DB und nutzt Spalten aus Models.AppUser
}