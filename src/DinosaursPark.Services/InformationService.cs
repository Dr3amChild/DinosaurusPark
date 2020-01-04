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
        private readonly IInformationRepository _repository;
        private readonly IDinoRepository _dinosaursRepository;
        private readonly IMapper _mapper;

        public InformationService(IInformationRepository repository, IDinoRepository dinosaursRepository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _dinosaursRepository = dinosaursRepository ?? throw new ArgumentNullException(nameof(dinosaursRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TItem> Get<TItem>()
        {
            var items = await _repository.Get();
            int dinosaursCount = await _dinosaursRepository.DinosaursCount();
            int speciesCount = await _dinosaursRepository.SpeciesCount();
            var countInformation = new CountInformation(speciesCount, dinosaursCount);
            return _mapper.Map<TItem>((items, countInformation));
        }
    }
}