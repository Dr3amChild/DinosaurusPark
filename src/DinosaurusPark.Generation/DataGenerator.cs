using Bogus;
using DinosaurusPark.Contracts;
using DinosaurusPark.Contracts.Models;
using DinosaurusPark.Contracts.Repositories;
using DinosaurusPark.Generation.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaurusPark.Generation
{
    public class DataGenerator : IDataGenerator
    {
        private readonly IDinoRepository _dinoRepository;
        private readonly Faker<Species> _speciesFaker = new Faker<Species>();
        private readonly Faker<Dinosaur> _dinoFaker = new Faker<Dinosaur>();

        public DataGenerator(IDinoRepository dinoRepository)
        {
            _dinoRepository = dinoRepository ?? throw new ArgumentNullException(nameof(dinoRepository));
        }

        public async Task Generate(int speciesCount, int dinosaursCount)
        {
            if (speciesCount < 0)
                throw new GenerationException($"{nameof(speciesCount)} must be grater than 0");

            if (dinosaursCount < 0)
                throw new GenerationException($"{nameof(dinosaursCount)} must be grater than 0");

            var species = Enumerable.Range(1, speciesCount).Select(i => GenerateSpecies()).ToArray();
            var rnd = new Random();
            var dinosaurs = Enumerable.Range(1, dinosaursCount).Select(id => GenerateDinosaur(species[rnd.Next(0, speciesCount)])).ToArray();

            await Save(species, dinosaurs);
        }

        private Species GenerateSpecies()
        {
            return _speciesFaker
                .CustomInstantiator(f =>
                    new Species
                    {
                        FoodType = f.Random.Enum<FoodType>(),
                        Name = f.Random.Word(),
                        Description = f.Lorem.Paragraph(),
                    });
        }

        private Dinosaur GenerateDinosaur(Species species)
        {
            return _dinoFaker
                .CustomInstantiator(f =>
                    new Dinosaur
                    {
                        Species = species,
                        Name = f.Random.Word(),
                    });
        }

        private async Task Save(Species[] species, Dinosaur[] dinos)
        {
            await _dinoRepository.AddSpecies(species);
            await _dinoRepository.AddDinosaurs(dinos);
            await _dinoRepository.Commit();
        }
    }
}
