using AutoMapper;
using DinosaursPark.Contracts.Repositories;
using DinosaursPark.Contracts.Services;
using System;
using System.Threading.Tasks;

namespace DinosaursPark.Services
{
    public class InformationService : IInformationService
    {
        private readonly IInformationRepository _repository;
        private readonly IMapper _mapper;

        public InformationService(IInformationRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TItem> Get<TItem>()
        {
            var items = await _repository.Get();
            return _mapper.Map<TItem>(items);
        }
    }
}