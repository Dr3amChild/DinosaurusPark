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
            return await _context
                    .Dinosaurs
                    .GroupBy(d => d.Species)
                    .Select(gr => new SpeciesInformation
                    {
                        SpeciesName = gr.Key.Name,
                        Count = gr.Count(),
                    })
                    .ToArrayAsync();
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