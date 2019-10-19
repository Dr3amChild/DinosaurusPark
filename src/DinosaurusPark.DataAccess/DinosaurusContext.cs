using System;
using DinosaurusPark.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace DinosaurusPark.DataAccess
{
    public class DinosaurusContext : DbContext
    {
        private readonly DbSettings _settings;

        public DinosaurusContext(DbSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public DbSet<Dinosaur> Dinosaurs { get; set; }

        public DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Species>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Dinosaur>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
