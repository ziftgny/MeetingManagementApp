using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().HasData(
                new Meeting { Id = 1, Name = "pazar toplantısı", Description = "deneme", EndTime = System.DateTime.Now, StartTime = System.DateTime.Now, DocumentURL = "deneme" },
                new Meeting { Id = 2, Name = "sali toplantısı", Description = "deneme", EndTime = System.DateTime.Now, StartTime = System.DateTime.Now, DocumentURL = "deneme" },
                new Meeting { Id = 3, Name = "toplanmantısı", Description = "deneme", EndTime = System.DateTime.Now, StartTime = System.DateTime.Now, DocumentURL = "deneme" }
                ); 
        }
    }
}
