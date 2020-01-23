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
    /// <summary>
    /// Важное замечание.
    /// Генерация данных библиотекой Bogus выполняется довольно медленно.
    /// Поэтому, ожидая создание пары миллионов объектов,
    /// можно успеть родить детей и дождаться появления внуков.
    /// В силу того, что это лишь демонстрационный проект,
    /// мне совсем не хотелось бы менять библиотеку,
    /// и тем более писать генерацию рандомных данных вручную,
    /// Хотя, может потом что-то придумаю.
    /// </summary>
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

            var species = Enumerable.Range(1, speciesCount).Select(id => GenerateSpecies()).ToArray();
            species = SolveSpeciesCollisiions(species);
            var rnd = new Random();
            var images = _imageProvider.GetPaths();
            var dinosaurs = Enumerable.Range(1, dinosaursCount).Select(id => GenerateDinosaur(species[rnd.Next(0, speciesCount)], images)).ToArray();

            await Save(parkInfo, species.ToArray(), dinosaurs);
            return new GenerationResult(parkInfo, species, dinosaurs);
        }

        private ParkInformation GenerateparkInfo()
        {
            return _infoFaker
                .CustomInstantiator(f =>
                    new ParkInformation
                    {
                        Name = string.Join(" ", f.Random.WordsArray(2).Select(w => w.FirstUp())),
                        Area = f.Random.Double(10, 1000),
                        Address = $"{f.Address.Country()}, {f.Address.City()}, {f.Address.StreetName()}, {f.Address.BuildingNumber()}"
                    });
        }

        private Species GenerateSpecies()
        {
            return _speciesFaker
                .CustomInstantiator(f =>
                    new Species
                    {
                        FoodType = f.Random.Enum<FoodType>(),
                        Name = GenerateSpeciesName(f),
                        Description = f.Lorem.Paragraph(),
                    });
        }

        private string GenerateSpeciesName(Faker faker)
        {
            var words = faker.Lorem.Words(2);
            (string Firstname, string Lastname) result =  (words[0].FirstUp(), words[1].FirstUp());
            result.Firstname = ModifyName(result.Firstname, "us");
            result.Lastname = ModifyName(result.Lastname, "is");            
            return FullnameToString(result);
        }

        private Species[] SolveSpeciesCollisiions(IReadOnlyCollection<Species> species)
        {
            var group = species.GroupBy(s => s.Name);
            return group.SelectMany(gr => 
            {
                if (gr.Count() == 1)
                    return gr;

                return gr.Select((s, i) => 
                {
                    if (i > 0)
                        s.Name += $" {i + 1}";
                    return s;
                });
            })
            .ToArray();
        }

        private static string ModifyName(string input, string postfix)
        {
            if (!input.EndsWith(postfix))
                input += postfix;
            return input;
        }

        private string FullnameToString((string Firstname, string Lastname) fullname)
        {
            return $"{fullname.Firstname} {fullname.Lastname}";
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