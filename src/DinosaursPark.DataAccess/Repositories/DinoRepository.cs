﻿using DinosaursPark.Contracts.Exceptions;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursPark.DataAccess.Repositories
{
    public class DinoRepository : IDinoRepository, IDisposable
    {
        private readonly DinosaursContext _context;

        public DinoRepository(DinosaursContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Dinosaur> GetById(int id)
        {
            return await _context
                           .Dinosaurs
                           .Include(d => d.Species)
                           .SingleOrDefaultAsync(d => d.Id == id)
                   ?? throw new NotFoundException($"Dinosaur with id {id} not found");
        }

        public async Task<IReadOnlyCollection<Dinosaur>> GetAll(int count, int offset)
        {
            return await _context
                    .Dinosaurs
                    .Include(d => d.Species)
                    .OrderBy(d => d.Id)
                    .Skip(offset)
                    .Take(count)
                    .Select(d => new Dinosaur(d))
                    .ToArrayAsync();
        }

        public async Task<int> DinosaursCount()
        {
            return await _context.Dinosaurs.CountAsync();
        }

        public async Task<int> SpeciesCount()
        {
            return await _context.Species.CountAsync();
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
    }
}