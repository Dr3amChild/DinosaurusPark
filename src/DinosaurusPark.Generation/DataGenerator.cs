using Bogus;
using DinosaurusPark.Contracts;
using DinosaurusPark.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinosaurusPark.Generation.Exceptions;

namespace DinosaurusPark.Generation
{
    public class DataGenerator : IDataGenerator
    {
        private readonly Faker<Species> _speciesFaker = new Faker<Species>();

        private readonly Faker<Dinosaur> _dinoFaker = new Faker<Dinosaur>();

        public async Task Generate(int speciesCount, int dinosaursCount)
        {
            if (speciesCount < 0)
                throw new GenerationException($"{nameof(speciesCount)} must be grater than 0");

            if (dinosaursCount < 0)
                throw new GenerationException($"{nameof(dinosaursCount)} must be grater than 0");

            var species = Enumerable.Range(1, speciesCount).Select(GenerateSpecies).ToArray();
            var rnd = new Random();
            var dinosaurs = Enumerable.Range(1, dinosaursCount).Select(id => GenerateDinosaur(id, species[rnd.Next(0, speciesCount)])).ToArray();

            await Save(species, dinosaurs);
        }

        private Species GenerateSpecies(int id)
        {
            return _speciesFaker
                .CustomInstantiator(f =>
                    new Species
                    {
                        Id = id,
                        FoodType = f.Random.Enum(Enum.GetValues(typeof(FoodType)).OfType<FoodType>().ToArray()),
                        Name = f.Random.Word(),
                        Description = f.Lorem.Paragraph(),
                    });
        }

        private Dinosaur GenerateDinosaur(int id, Species species)
        {
            return _dinoFaker
                .CustomInstantiator(f =>
                    new Dinosaur
                    {
                        Id = id,
                        Species = species,
                        Name = f.Random.Word(),
                    });
        }

        private async Task Save(IEnumerable<Species> species, IEnumerable<Dinosaur> dinos)
        {
            // todo replace with await _repository.Save()
            await Task.CompletedTask;
        }
    }
}
