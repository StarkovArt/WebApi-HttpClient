using System.Data.Entity;

namespace Task.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
        {
            Database.SetInitializer<EFDbContext>(new ApplicationDbIntializer());
        }
        public DbSet<Task.Domain.Entity.Task> Tasks { get; set; }
    }
}
