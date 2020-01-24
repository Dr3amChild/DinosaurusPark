using AutoMapper;
using DinosaursPark.Contracts.Repositories;
using DinosaursPark.Contracts.Services;
using System;
using System.Threading.Tasks;
using DinosaursPark.Contracts.Models;

namespace DinosaursPark.Services
{
    public class InformationService : IInformationService
    {
        private readonly IDinosaursService _dinosaursService;
        private readonly IInformationRepository _informationRepository;
        private readonly IDinoRepository _dinosaursRepository;
        private readonly IMapper _mapper;

        public InformationService(
            IDinosaursService dinosaursService,
            IInformationRepository informationRepository,
            IDinoRepository dinosaursRepository,
            IMapper mapper)
        {
            _dinosaursService = dinosaursService ?? throw new ArgumentNullException(nameof(dinosaursService));
            _informationRepository = informationRepository ?? throw new ArgumentNullException(nameof(informationRepository));
            _dinosaursRepository = dinosaursRepository ?? throw new ArgumentNullException(nameof(dinosaursRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task<TItem> GetParkInfo<TItem>()
        {
            var items = await _informationRepository.GetParkInfo();
            int dinosaursCount = await _dinosaursRepository.DinosaursCount();
            int speciesCount = await _dinosaursRepository.SpeciesCount();
            var countInformation = new CountInformation(speciesCount, dinosaursCount);
            return _mapper.Map<TItem>((items, countInformation));
        }

        public async Task<TItem> GetSpeciesInfo<TItem>()
        {
            var items = await _informationRepository.GetSpeciesInfo();
            return _mapper.Map<TItem>(items);
        }

        public async Task DeleteAll()
        {
            // TODO тут надо бы прикруть какой-нибудь UnitOfWork или транзакцию
            await _dinosaursService.DeleteAll();
            await _informationRepository.DeleteAll();
        }
    }
}