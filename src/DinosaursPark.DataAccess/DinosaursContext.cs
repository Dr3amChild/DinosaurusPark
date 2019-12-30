using System;
using DinosaursPark.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace DinosaursPark.DataAccess
{
    public class DinosaursContext : DbContext
    {
        private readonly DbSettings _settings;

        public DinosaursContext(DbSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public DbSet<Dinosaur> Dinosaurs { get; set; }

        public DbSet<Species> Species { get; set; }

        public DbSet<ParkInformation> Infomration { get; set; }

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

            modelBuilder.Entity<ParkInformation>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
