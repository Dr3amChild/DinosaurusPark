using System.Collections.Generic;

namespace DinosaurusPark.IntegrationTests.Responses
{
    public class DinosaursResponse
    {
        public IReadOnlyCollection<DinosaurResponse> Items { get; set; }

        public class DinosaurResponse
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Gender { get; set; }

            public int SpeciesId { get; set; }
        }
    }
}
