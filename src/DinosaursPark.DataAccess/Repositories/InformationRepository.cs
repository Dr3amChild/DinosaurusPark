using DinosaursPark.Contracts.Exceptions;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<ParkInformation> Get()
        {
            return await _context.Infomration.SingleOrDefaultAsync()
                   ?? throw new NotFoundException($"Information not found");
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