using DinosaursPark.Contracts.Models;
using System.Collections.Generic;

namespace DinosaursPark.IntegrationTests.Responses
{
    public class GenerationResponse
    {
        public IReadOnlyCollection<SpeciesResponse> Species { get; set; }

        public IReadOnlyCollection<DinosaurResponse> Dinosaurs { get; set; }

        public class SpeciesResponse
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public FoodType FoodType { get; set; }

            public string Description { get; set; }
        }

        public class DinosaurResponse
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public Gender Gender { get; set; }

            public int SpeciesId { get; set; }

            public Species Species { get; set; }
        }
    }
}