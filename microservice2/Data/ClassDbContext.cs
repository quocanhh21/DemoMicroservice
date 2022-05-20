using Microsoft.EntityFrameworkCore;

namespace microservice2.Data
{
    public class ClassDbContext : DbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {

        }

        public DbSet<Class> Clases { get; set; }
    }
}
