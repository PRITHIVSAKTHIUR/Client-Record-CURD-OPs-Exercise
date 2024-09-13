using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)

    {
        //public DbSet<Client>? Clients { get; set; } = default;

        public DbSet<Client> Clients { get; set; }
    }
}
