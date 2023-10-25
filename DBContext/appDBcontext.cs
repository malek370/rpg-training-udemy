global using Microsoft.EntityFrameworkCore;
namespace rpg_training.DBContext
{
    public class appDBcontext:DbContext
    {
        public DbSet<Character> characters { set; get; }
        public DbSet<User> users { set; get; }
        public appDBcontext(DbContextOptions<appDBcontext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character() { id = 1, Name = "Slim", Class = RPGClass.Mage },
            new Character() { id = 2, Name = "chaima", Class = RPGClass.Knight },
            new Character() { id = 3, Name = "Mariem", Class = RPGClass.Cleric }
            );
        }
    }
}
