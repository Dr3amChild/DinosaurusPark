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
    public class InformationService : BaseService, IInformationService
    {
        private readonly IDinosaursService _dinosaursService;
        private readonly IInformationRepository _informationRepository;
        private readonly IDinoRepository _dinosaursRepository;

        public InformationService(
            IDinosaursService dinosaursService,
            IInformationRepository informationRepository,
            IDinoRepository dinosaursRepository,
            IMapper mapper, ILogger<DinosaursService> logger)
            : base(mapper, logger)
        {
            _dinosaursService = dinosaursService ?? throw new ArgumentNullException(nameof(dinosaursService));
            _informationRepository = informationRepository ?? throw new ArgumentNullException(nameof(informationRepository));
            _dinosaursRepository = dinosaursRepository ?? throw new ArgumentNullException(nameof(dinosaursRepository));
        }
        
        public async Task<TItem> GetParkInfo<TItem>()
        {
            Logger.LogDebug($"{nameof(InformationService)}.{nameof(GetParkInfo)}()");
            var items = await _informationRepository.GetParkInfo();
            int dinosaursCount = await _dinosaursRepository.DinosaursCount();
            int speciesCount = await _dinosaursRepository.SpeciesCount();
            var countInformation = new CountInformation(speciesCount, dinosaursCount);
            return Mapper.Map<TItem>((items, countInformation));
        }

        public async Task<PagingResult<TItem>> GetSpeciesInfo<TItem>(int pageNumber, int pageSize)
        {
            Logger.LogDebug($"{nameof(InformationService)}.{nameof(GetSpeciesInfo)}({pageNumber}, {pageSize})");
            int offset = (pageNumber - 1) * pageSize;
            var items = await _informationRepository.GetSpeciesInfo(pageSize, offset);
            int count = await _dinosaursRepository.SpeciesCount();
            var mappedItems =  Mapper.Map<IEnumerable<TItem>>(items);
            return new PagingResult<TItem>(mappedItems, pageNumber, pageSize, count);
        }

        public async Task DeleteAll()
        {
            Logger.LogDebug($"{nameof(InformationService)}.{nameof(DeleteAll)}()");
            // TODO тут надо бы прикруть какой-нибудь UnitOfWork или транзакцию
            await _dinosaursService.DeleteAll();
            await _informationRepository.DeleteAll();
        }
    }
}