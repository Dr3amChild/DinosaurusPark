﻿using DinosaursPark.Contracts.Exceptions;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursPark.DataAccess.Repositories
{
    public class InformationRepository : BaseRepository, IInformationRepository
    {
        public InformationRepository(DinosaursContext context)
            : base(context)
        {
        }

        public async Task<ParkInformation> GetParkInfo()
        {
            return await Context
                           .Information
                           .AsNoTracking()
                           .FirstOrDefaultAsync()
                   ?? throw new NotFoundException($"Information not found");
        }

        public async Task<IReadOnlyCollection<SpeciesInformation>> GetSpeciesInfo(int count, int offset)
        {
            var query = from dinosaur in Context.Dinosaurs
                     join species in Context.Species on dinosaur.SpeciesId equals species.Id
                     group dinosaur by species.Name into gr
                     select new SpeciesInformation { SpeciesName = gr.Key, Count = gr.Count() };
            return await query
                            .OrderByDescending(s => s.Count)
                            .Skip(offset)
                            .Take(count)
                            .AsNoTracking()
                            .ToArrayAsync();
        }

        public async Task Add(ParkInformation info)
        {
            Context.Attach(info);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAll()
        {
            Context.Information.RemoveRange(Context.Information);
            await Context.SaveChangesAsync();
        }
    }
}