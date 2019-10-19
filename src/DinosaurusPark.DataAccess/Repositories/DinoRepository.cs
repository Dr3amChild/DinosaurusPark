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
    public class DinoRepository : IDinoRepository, IDisposable
    {
        private readonly DinosaurusContext _context;

        public DinoRepository(DinosaurusContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Dinosaur> GetById(int id)
        {
            return await _context.Dinosaurs.SingleOrDefaultAsync(d => d.Id == id)
                   ?? throw new NotFoundException($"Dinosaur with id {id} not found");
        }

        public async Task<IReadOnlyCollection<Dinosaur>> GetAll(int count, int offset)
        {
            return await _context.Dinosaurs.OrderBy(d => d.Id).Skip(offset).Take(count).ToArrayAsync();
        }

        public async Task AddSpecies(params Species[] species)
        {
            await _context.Species.AddRangeAsync(species);
        }

        public async Task AddDinosaurs(params Dinosaur[] dinosaurs)
        {
            await _context.Dinosaurs.AddRangeAsync(dinosaurs);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<int> GetCount()
        {
            return await _context.Dinosaurs.CountAsync();
        }
    }
}