using Microsoft.EntityFrameworkCore;

namespace eventease.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BOOKINGS> BOOKINGS { get; set; }
        public DbSet<EVENTS> EVENTS { get; set; }
        public DbSet<VENUES> VENUES { get; set; }
    }
}
    

