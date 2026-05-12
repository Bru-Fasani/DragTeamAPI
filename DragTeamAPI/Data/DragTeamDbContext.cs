using DragTeamAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DragTeamAPI.Data
{
    public class DragTeamDbContext : DbContext
    {
        public DragTeamDbContext(DbContextOptions<DragTeamDbContext> options) : base(options)
        {
        }
        public DbSet<Entities.Team> Teams { get; set; }
        public DbSet<Entities.Driver> Drivers { get; set; }
        public DbSet<Entities.Car> Cars { get; set; }
        public DbSet<Entities.Mechanic> Mechanics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Drivers)
                .WithOne(d => d.Team)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Cars)
                .WithOne(c => c.Team)
                .HasForeignKey(c => c.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .Property(c => c.QualifyingTime)
                .HasPrecision(5, 3);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Mechanics)
                .WithOne(m => m.Team)
                .HasForeignKey(m => m.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
