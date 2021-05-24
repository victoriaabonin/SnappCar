using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace SnappetGarage.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SnappetCar> SnappetCars { get; set; }
    }
}
