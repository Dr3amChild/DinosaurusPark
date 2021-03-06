﻿using DinosaursPark.Contracts.Exceptions;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursPark.DataAccess.Repositories
{
    public class DinoRepository : BaseRepository, IDinoRepository
    {
        public DinoRepository(DinosaursContext context)
         : base(context)
        {
        }

        public async Task<Dinosaur> GetById(int id)
        {
            return await Context
                           .Dinosaurs
                           .Include(d => d.Species)
                           .AsNoTracking()
                           .SingleOrDefaultAsync(d => d.Id == id)
                   ?? throw new NotFoundException($"Dinosaur with id {id} not found");
        }

        public async Task<IReadOnlyCollection<Dinosaur>> GetAll(int count, int offset)
        {
            return await Context
                    .Dinosaurs
                    .Include(d => d.Species)
                    .OrderBy(d => d.Id)
                    .Skip(offset)
                    .Take(count)
                    .Select(d => new Dinosaur(d))
                    .AsNoTracking()
                    .ToArrayAsync();
        }

        public async Task<int> DinosaursCount()
        {
            return await Context.Dinosaurs.AsNoTracking().CountAsync();
        }

        public async Task<int> SpeciesCount()
        {
            return await Context.Species.AsNoTracking().CountAsync();
        }

        public async Task AddSpecies(params Species[] species)
        {
            await Context.Species.AddRangeAsync(species);
        }

        public async Task AddDinosaurs(params Dinosaur[] dinosaurs)
        {
            await Context.Dinosaurs.AddRangeAsync(dinosaurs);
        }

        public void DeleteAllDinosaurs()
        {
            Context.Dinosaurs.RemoveRange(Context.Dinosaurs);
        }

        public void DeleteAllSpecies()
        {
            Context.Species.RemoveRange(Context.Species);
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}