using Bogus;
using DinosaurusPark.Contracts;
using DinosaurusPark.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaurusPark.Generation
{
    public class DataGenerator : IDataGenerator
    {
        private readonly Faker<Species> _speciesFaker = new Faker<Species>();

        private readonly Faker<Dinosaur> _dinoFaker = new Faker<Dinosaur>();

        public async Task Generate(int speciesCount, int disnosaursCount)
        {
            var species = Enumerable.Range(1, speciesCount).Select(GenerateSpecies).ToArray();
            var rnd = new Random();
            var dinosaurs = Enumerable.Range(1, disnosaursCount).Select(id => GenerateDinosaur(id, species[rnd.Next(0, speciesCount)])).ToArray();

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
