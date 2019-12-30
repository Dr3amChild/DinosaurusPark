using AutoMapper;
using Bogus;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using DinosaursPark.Contracts.Services;
using DinosaursPark.Extensions;
using DinosaursPark.Generation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursPark.Generation
{
    public class DataGenerator : IDataGenerator
    {
        private readonly IInformationRepository _infoRepository;
        private readonly IDinoRepository _dinoRepository;
        private readonly IImageProvider _imageProvider;
        private readonly IMapper _mapper;
        private readonly Faker<ParkInformation> _infoFaker = new Faker<ParkInformation>();
        private readonly Faker<Species> _speciesFaker = new Faker<Species>();
        private readonly Faker<Dinosaur> _dinoFaker = new Faker<Dinosaur>("ru");

        public DataGenerator(IInformationRepository infoRepository, IDinoRepository dinoRepository, IImageProvider imageProvider, IMapper mapper)
        {
            _infoRepository = infoRepository ?? throw new ArgumentNullException(nameof(infoRepository));
            _dinoRepository = dinoRepository ?? throw new ArgumentNullException(nameof(dinoRepository));
            _imageProvider = imageProvider ?? throw new ArgumentNullException(nameof(_imageProvider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GenerationResult> Generate(int speciesCount, int dinosaursCount)
        {
            if (speciesCount < 0)
                throw new GenerationException($"{nameof(speciesCount)} must be grater than 0");

            if (dinosaursCount < 0)
                throw new GenerationException($"{nameof(dinosaursCount)} must be grater than 0");

            if (speciesCount == 0 && dinosaursCount > 0)
                throw new GenerationException($"{nameof(speciesCount)} must be grater than 0 if {dinosaursCount} is positive");

            var parkInfo = GenerateparkInfo();
            var species = Enumerable.Range(1, speciesCount).Select(i => GenerateSpecies()).ToArray();
            var rnd = new Random();
            var images = _imageProvider.GetPaths();
            var dinosaurs = Enumerable.Range(1, dinosaursCount).Select(id => GenerateDinosaur(species[rnd.Next(0, speciesCount)], images)).ToArray();

            await Save(parkInfo, species, dinosaurs);
            return new GenerationResult(parkInfo, species, dinosaurs);
        }

        private ParkInformation GenerateparkInfo()
        {
            return _infoFaker
                .CustomInstantiator(f =>
                    new ParkInformation
                    {
                        Name = f.Random.Words(2),
                        Area = f.Random.Double(10, 1000)
                    });
        }

        private Species GenerateSpecies()
        {
            return _speciesFaker
                .CustomInstantiator(f =>
                    new Species
                    {
                        FoodType = f.Random.Enum<FoodType>(),
                        Name = Latinize(f),
                        Description = f.Lorem.Paragraph(),
                    });
        }

        private string Latinize(Faker faker)
        {
            static string ModifyName(string input, string postfix)
            {
                if (!input.EndsWith(postfix))
                    input += postfix;
                return input;
            }

            var words = faker.Lorem.Words(2);
            const string namePostfix = "us";
            if (!words[0].EndsWith(namePostfix))
                words[0] = words[0] + namePostfix;

            words[0] = ModifyName(words[0], "us");
            words[1] = ModifyName(words[1], "is");

            return string.Join(" ", words.Select(w => w.FirstUp()));
        }

        private Dinosaur GenerateDinosaur(Species species, IReadOnlyList<string> images)
        {
            var gender = new Faker().Random.Enum<Gender>();
            var bogusGender = _mapper.Map<Bogus.DataSets.Name.Gender>(gender);
            return _dinoFaker
                .CustomInstantiator(f =>
                    new Dinosaur
                    {
                        Species = species,
                        Name = f.Name.FirstName(bogusGender),
                        Gender = gender,
                        Age = f.Random.Int(1, 100),
                        Weight = f.Random.Int(1, 3000),
                        Height = f.Random.Int(1, 500),
                        Image = images[f.Random.Int(0, images.Count - 1)],
                    });
        }

        private async Task Save(ParkInformation info, Species[] species, Dinosaur[] dinos)
        {
            await _infoRepository.Add(info);
            await _dinoRepository.AddSpecies(species);
            await _dinoRepository.AddDinosaurs(dinos);
            await _dinoRepository.Commit();
        }
    }
}