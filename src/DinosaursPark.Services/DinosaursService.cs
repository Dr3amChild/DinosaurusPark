using AutoMapper;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using DinosaursPark.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinosaursPark.Services
{
    public class DinosaursService : IDinosaursService
    {
        private readonly IDinoRepository _dinorepository;
        private readonly IMapper _mapper;

        public DinosaursService(IDinoRepository dinoRepository, IMapper mapper)
        {
            _dinorepository = dinoRepository ?? throw new ArgumentNullException(nameof(dinoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TItem> Get<TItem>(int id)
        {
            var items = await _dinorepository.GetById(id);
            return _mapper.Map<TItem>(items);
        }

        public async Task<PagingResult<TItem>> Get<TItem>(int pageNumber, int pageSize)
        {
            int offset = (pageNumber - 1) * pageSize;
            int count = await _dinorepository.GetCount();
            var items = await _dinorepository.GetAll(pageSize, offset);
            var mappedItems = _mapper.Map<IEnumerable<TItem>>(items);
            return new PagingResult<TItem>(mappedItems, pageNumber, pageSize, count);
        }
    }
}