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
    public class DinosaursService : BaseService, IDinosaursService
    {
        private readonly IDinoRepository _dinosaursRepository;

        public DinosaursService(IDinoRepository dinosaursRepository, IMapper mapper, ILogger<DinosaursService> logger)
            : base(mapper, logger)
        {
            _dinosaursRepository = dinosaursRepository ?? throw new ArgumentNullException(nameof(dinosaursRepository));
        }

        public async Task<TItem> Get<TItem>(int id)
        {
            Logger.LogDebug($"{nameof(DinosaursService)}.{nameof(Get)}({id})");
            var items = await _dinosaursRepository.GetById(id);
            return Mapper.Map<TItem>(items);
        }

        public async Task<PagingResult<TItem>> Get<TItem>(int pageNumber, int pageSize)
        {
            Logger.LogDebug($"{nameof(DinosaursService)}.{nameof(Get)}({pageNumber}, {pageSize})");
            int offset = (pageNumber - 1) * pageSize;
            int count = await _dinosaursRepository.DinosaursCount();
            var items = await _dinosaursRepository.GetAll(pageSize, offset);
            var mappedItems = Mapper.Map<IEnumerable<TItem>>(items);
            return new PagingResult<TItem>(mappedItems, pageNumber, pageSize, count);
        }

        public async Task DeleteAll()
        {
            Logger.LogDebug($"{nameof(DinosaursService)}.{nameof(DeleteAll)}()");
            _dinosaursRepository.DeleteAllDinosaurs();
            _dinosaursRepository.DeleteAllSpecies();
            await _dinosaursRepository.Commit();
            Logger.LogInformation("All data has been deleted");
        }
    }
}