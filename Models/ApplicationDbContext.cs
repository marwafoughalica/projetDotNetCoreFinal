using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Mini_ProjetDonetCore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        
        {
           
        }

        public DbSet<Client> client { get; set; }
        public DbSet<Voiture> voiture { get; set; }

        public DbSet<Location> location { get; set; }

    }
}
