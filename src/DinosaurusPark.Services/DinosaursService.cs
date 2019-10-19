using DinosaurusPark.Contracts.Models;
using DinosaurusPark.Contracts.Repositories;
using DinosaurusPark.Contracts.Services;
using System;
using System.Threading.Tasks;

namespace DinosaurusPark.Services
{
    public class DinosaursService : IDinosaursService
    {
        private readonly IDinoRepository _dinorepository;

        public DinosaursService(IDinoRepository dinoRepository)
        {
            _dinorepository = dinoRepository ?? throw new ArgumentNullException(nameof(dinoRepository));
        }

        public async Task<PagingResult<Dinosaur>> Get(int pageNumber, int pageSize)
        {
            int offset = (pageNumber - 1) * pageSize;
            int count = await _dinorepository.GetCount();
            var items = await _dinorepository.GetAll(pageSize, offset);
            return new PagingResult<Dinosaur>(items, pageNumber, pageSize, count);
        }
    }
}