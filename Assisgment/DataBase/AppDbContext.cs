using Assisgment.Model;
using Microsoft.EntityFrameworkCore;

namespace Assisgment.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team > Teams { get; set; }
        public DbSet<Competition> Competions { get; set; }
        public DbSet<Coach> Coachs { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamId);
            modelBuilder.Entity<Team>()
                .HasMany(x => x.Competitions)
                .WithMany(x => x.Teams);
            modelBuilder.Entity<Coach>()
                .HasOne(x => x.Team)
                .WithOne(x => x.Coach)
                .HasForeignKey<Team>(x => x.CoachId);
            modelBuilder.Entity<Team>()
                .HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Coach>()
                 .HasData(
                new Coach { Id = 1, Name = "Yassin", ExperinceYears = 3, Specilzation = "sports" },
                 new Coach { Id = 2, Name = "omar", ExperinceYears = 2, Specilzation = "football" },
                  new Coach { Id = 3, Name = "Joo", ExperinceYears = 5, Specilzation = "Basket" },
                   new Coach { Id = 4, Name = "ahmed", ExperinceYears = 10, Specilzation = "football" }

                );
            modelBuilder.Entity<Team>
               ().HasData(
                new Team { Id = 1, Name = "Alahly", City = "Cairo", CoachId = 1 },
                new Team { Id = 2, Name = "Elzamalek", City = "Giza", CoachId = 2 },
                new Team { Id = 3, Name = "Zed", City = "Cairo", CoachId = 3 },
                new Team { Id = 4, Name = "Smouha", City = "Alex", CoachId = 4 }
                );
            modelBuilder.Entity<Player>
                ().HasData(
                new Player { Id = 1, FullName = "Zizo", Age = 29, Position = "Attack", TeamId = 1 },
                 new Player { Id = 2, FullName = "BenSharki", Age = 30, Position = "Attack", TeamId = 1 },
                  new Player { Id = 3, FullName = "Elgezeri", Age = 32, Position = "Attack", TeamId = 2 },
                   new Player { Id = 4, FullName = "Koka", Age = 18, Position = "Defend", TeamId = 1 },
                    new Player { Id = 5, FullName = "3wad", Age = 35, Position = "GoalKeper", TeamId = 2 }
                );
            modelBuilder.Entity<Competition>().HasData(
                new Competition { Id = 1, DateTime = new DateTime(6/25/2025) , Location = "Amireca", Tiitle = "Copa" },
                new Competition { Id = 2, DateTime =  new DateTime(7/25/2025) , Location = "Asia", Tiitle = "World cup" },
                new Competition { Id = 3, DateTime =new DateTime(10/9/2025)  , Location = "Arica", Tiitle = "Euro" }
                );






        }
    }
}
