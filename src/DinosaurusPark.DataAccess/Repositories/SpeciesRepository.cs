using DinosaurusPark.Contracts.Exceptions;
using DinosaurusPark.Contracts.Models;
using DinosaurusPark.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DinosaurusPark.DataAccess.Repositories
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly DbSettings _settings;

        public SpeciesRepository(DbSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<Species> GetById(int id)
        {
            using (var ctx = new DinosaurusContext(_settings))
            {
                return await ctx.Species.SingleOrDefaultAsync(d => d.Id == id)
                       ?? throw new NotFoundException($"Species with id {id} not found");
            }
        }

        public async Task Save(params Species[] species)
        {
            using (var ctx = new DinosaurusContext(_settings))
            {
                await ctx.Species.AddRangeAsync(species);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
