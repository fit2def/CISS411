using Microsoft.EntityFrameworkCore;

namespace CISS411.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Register your models here.
        public DbSet<ExampleModel> Models { get; set; }
    }
}
