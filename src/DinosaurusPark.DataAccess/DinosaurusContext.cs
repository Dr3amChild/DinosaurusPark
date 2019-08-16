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
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_settings.ConnectionString);
        }

        public DbSet<Dinosaur> Dinosaurs { get; set; }

        public DbSet<Species> Species { get; set; }
    }
}
