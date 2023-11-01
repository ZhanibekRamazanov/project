using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }

}
