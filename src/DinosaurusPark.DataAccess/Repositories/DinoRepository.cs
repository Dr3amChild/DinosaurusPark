using DinosaurusPark.Contracts.Exceptions;
using DinosaurusPark.Contracts.Models;
using DinosaurusPark.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaurusPark.DataAccess.Repositories
{
    public class DinoRepository : IDinoRepository
    {
        private readonly DbSettings _settings;

        public DinoRepository(DbSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<Dinosaur> GetById(int id)
        {
            using (var ctx = new DinosaurusContext(_settings))
            {
                return await ctx.Dinosaurs.SingleOrDefaultAsync(d => d.Id == id)
                       ?? throw new NotFoundException($"Dinosaur with id {id} not found");
            }
        }

        public async Task<IReadOnlyCollection<Dinosaur>> GetAll(int count, int offset)
        {
            using (var ctx = new DinosaurusContext(_settings))
            {
                return await ctx.Dinosaurs.Skip(offset).Take(count).ToArrayAsync();
            }
        }

        public async Task Save(params Dinosaur[] dinosaurs)
        {
            try
            {
                using (var ctx = new DinosaurusContext(_settings))
                {
                    foreach (var dino in dinosaurs)
                    {
                        await ctx.Dinosaurs.AddAsync(dino);
                    }

                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
