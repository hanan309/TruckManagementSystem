using Microsoft.EntityFrameworkCore;
using TruckManagementSystem.API.Models;

namespace TruckManagementSystem.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<TruckManagementSystem.API.Models.Route> Routes { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckAssignment> TruckAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Route config
            modelBuilder.Entity<TruckManagementSystem.API.Models.Route>()
                .HasKey(r => r.RouteId);

            modelBuilder.Entity<TruckManagementSystem.API.Models.Route>()
                .Property(r => r.FromCity)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<TruckManagementSystem.API.Models.Route>()
                .Property(r => r.ToCity)
                .IsRequired()
                .HasMaxLength(100);

            // Truck config
            modelBuilder.Entity<Truck>()
                .HasKey(t => t.TruckId);

            modelBuilder.Entity<Truck>()
                .Property(t => t.Color)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Truck>()
                .Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Truck>()
                .Property(t => t.Size)
                .IsRequired();

            // TruckAssignment config (Many-to-Many via join table)
            modelBuilder.Entity<TruckAssignment>()
                .HasKey(ta => ta.AssignmentId);

            modelBuilder.Entity<TruckAssignment>()
                .HasOne(ta => ta.Truck)
                .WithMany(t => t.TruckAssignments)
                .HasForeignKey(ta => ta.TruckId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TruckAssignment>()
                .HasOne(ta => ta.Route)
                .WithMany(r => r.TruckAssignments)
                .HasForeignKey(ta => ta.RouteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TruckAssignment>()
                .Property(ta => ta.RoutePrice)
                .IsRequired();

            modelBuilder.Entity<TruckAssignment>()
                .Property(ta => ta.PetrolConsumption)
                .IsRequired();
        }
    }
}