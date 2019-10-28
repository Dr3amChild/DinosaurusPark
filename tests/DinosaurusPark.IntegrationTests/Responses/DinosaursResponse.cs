using System.Collections.Generic;

namespace DinosaurusPark.IntegrationTests.Responses
{
    public class DinosaursResponse
    {
        public IReadOnlyCollection<DinosaurResponse> Items { get; set; }
    }
}