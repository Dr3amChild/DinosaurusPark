using System;
using System.Collections.Generic;

namespace DinosaursPark.Contracts.Models
{
    public class GenerationResult
    {
        public GenerationResult(ParkInformation info, IReadOnlyCollection<Species> species, IReadOnlyCollection<Dinosaur> dinosaurs)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
            Species = species ?? throw new ArgumentNullException(nameof(species));
            Dinosaurs = dinosaurs ?? throw new ArgumentNullException(nameof(dinosaurs));
        }

        public ParkInformation Info { get; }

        public IReadOnlyCollection<Species> Species { get; }

        public IReadOnlyCollection<Dinosaur> Dinosaurs { get; }
    }
}