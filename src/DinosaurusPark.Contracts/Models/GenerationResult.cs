using System;
using System.Collections.Generic;

namespace DinosaurusPark.Contracts.Models
{
    public class GenerationResult
    {
        public GenerationResult(IReadOnlyCollection<Species> species, IReadOnlyCollection<Dinosaur> dinosaurs)
        {
            Species = species ?? throw new ArgumentNullException(nameof(species));
            Dinosaurs = dinosaurs ?? throw new ArgumentNullException(nameof(dinosaurs));
        }

        public IReadOnlyCollection<Species> Species { get; }

        public IReadOnlyCollection<Dinosaur> Dinosaurs { get; }
    }
}