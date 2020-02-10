using AutoMapper;
using Microsoft.Extensions.Logging;
using System;

namespace DinosaursPark.Services
{
    public abstract class BaseService
    {
        protected BaseService(IMapper mapper, ILogger<BaseService> logger)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected IMapper Mapper { get; } 
        protected ILogger<BaseService> Logger { get; }
    }
}