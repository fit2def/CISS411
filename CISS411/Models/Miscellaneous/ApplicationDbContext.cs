using CISS411.Models.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CISS411.Models.Miscellaneous
{
    public class ApplicationDbContext : IdentityDbContext<Member>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Register your models here as DbSet generics.
        public DbSet<Event> Events { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Registration> Registrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.UserId, r.EventId });
        }
    }
}
