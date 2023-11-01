global using Microsoft.EntityFrameworkCore;
namespace rpg_training.DBContext
{
    public class appDBcontext:DbContext
    {
        public DbSet<Character> characters { set; get; }
        public DbSet<User> users { set; get; }
        public DbSet<Weapon> weapons { set; get; }
        public DbSet<Skill> skills { set; get; }
        public appDBcontext(DbContextOptions<appDBcontext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill() { Id=1,Name="fire ball",Damage=20},
                new Skill() { Id = 2, Name = "8 gates", Damage = 200 },
                new Skill() { Id = 3, Name = "shadow clone", Damage = 33 },
                new Skill() { Id = 4, Name = "rasengan", Damage = 10 }
            );
            modelBuilder.Entity<Character>().HasData(
                new Character() { id = 1, Name = "Slim", Class = RPGClass.Mage },
            new Character() { id = 2, Name = "chaima", Class = RPGClass.Knight },
            new Character() { id = 3, Name = "Mariem", Class = RPGClass.Cleric }
            );
        }
    }
}
