using DinosaursPark.Contracts.Exceptions;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursPark.DataAccess.Repositories
{
    public class InformationRepository : IInformationRepository, IDisposable
    {
        private readonly DinosaursContext _context;

        public InformationRepository(DinosaursContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ParkInformation> GetParkInfo()
        {
            return await _context.Information.SingleOrDefaultAsync()
                   ?? throw new NotFoundException($"Information not found");
        }

        public async Task<IReadOnlyCollection<SpeciesInformation>> GetSpeciesInfo()
        {
            var query = from dinosaur in _context.Dinosaurs
                     join species in _context.Species on dinosaur.SpeciesId equals species.Id
                     group dinosaur by species.Name into gr
                     select new SpeciesInformation { SpeciesName = gr.Key, Count = gr.Count() };
            return await query.ToArrayAsync();
        }

        public async Task Add(ParkInformation info)
        {
            _context.Attach(info);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}