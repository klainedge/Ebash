using Microsoft.EntityFrameworkCore;

namespace Diceroller
{
    public class ApplicationContext : DbContext
    {
        public DbSet<toSQL> DiceDB { get; set; }
         
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dicedb;Trusted_Connection=True;");
        }
    }
}
