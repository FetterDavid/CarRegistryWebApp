using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Server.Models
{
    /// <summary>
    /// Represents the database context for the Car Registry application.
    /// </summary>
    public partial class CarRegistryDBContext : DbContext
    {
        public CarRegistryDBContext()
        {
        }

        public CarRegistryDBContext(DbContextOptions<CarRegistryDBContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Gets or sets the DbSet of cars in the database.
        /// </summary>
        public virtual DbSet<Car> Cars { get; set; } = null!;
        /// <summary>
        /// Gets or sets the DbSet of car ownership records in the database.
        /// </summary>
        public virtual DbSet<CarOwnership> CarOwnerships { get; set; } = null!;
        /// <summary>
        /// Gets or sets the DbSet of owners in the database.
        /// </summary>
        public virtual DbSet<Owner> Owners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarRegistryDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductionDate).HasColumnType("date");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarOwnership>(entity =>
            {
                entity.ToTable("CarOwnership");

                entity.HasIndex(e => e.CarId, "UQ__CarOwner__68A0342F508DE1E4")
                    .IsUnique();
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
