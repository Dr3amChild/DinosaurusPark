using AutoMapper;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using DinosaursPark.Contracts.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinosaursPark.Services
{
    public class DinosaursService : IDinosaursService
    {
        private readonly IDinoRepository _dinosaursRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DinosaursService> _logger;

        public DinosaursService(IDinoRepository dinosaursRepository, IMapper mapper, ILogger<DinosaursService> logger)
        {
            _dinosaursRepository = dinosaursRepository ?? throw new ArgumentNullException(nameof(dinosaursRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TItem> Get<TItem>(int id)
        {
            _logger.LogDebug($"{nameof(DinosaursService)}.{nameof(Get)}({id})");
            var items = await _dinosaursRepository.GetById(id);
            return _mapper.Map<TItem>(items);
        }

        public async Task<PagingResult<TItem>> Get<TItem>(int pageNumber, int pageSize)
        {
            _logger.LogDebug($"{nameof(DinosaursService)}.{nameof(Get)}({pageNumber}, {pageSize})");
            int offset = (pageNumber - 1) * pageSize;
            int count = await _dinosaursRepository.DinosaursCount();
            var items = await _dinosaursRepository.GetAll(pageSize, offset);
            var mappedItems = _mapper.Map<IEnumerable<TItem>>(items);
            return new PagingResult<TItem>(mappedItems, pageNumber, pageSize, count);
        }

        public async Task DeleteAll()
        {
            _logger.LogDebug($"{nameof(DinosaursService)}.{nameof(DeleteAll)}()");
            _dinosaursRepository.DeleteAllDinosaurs();
            _dinosaursRepository.DeleteAllSpecies();
            await _dinosaursRepository.Commit();
            _logger.LogInformation("All data has been deleted");
        }
    }
}