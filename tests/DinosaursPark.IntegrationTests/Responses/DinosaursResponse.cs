using System.Collections.Generic;

namespace DinosaursPark.IntegrationTests.Responses
{
    public class DinosaursResponse
    {
        public IReadOnlyCollection<DinosaurResponse> Items { get; set; }
    }
}