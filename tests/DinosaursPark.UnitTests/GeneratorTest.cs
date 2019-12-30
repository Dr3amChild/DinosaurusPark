using AutoMapper;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Contracts.Repositories;
using DinosaursPark.Contracts.Services;
using DinosaursPark.Generation;
using DinosaursPark.Generation.Exceptions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using BogusGender = Bogus.DataSets.Name.Gender;

namespace DinosaursPark.UnitTests
{
    public class GeneratorTest
    {
        private DataGenerator _generator;

        [SetUp]
        public void Setup()
        {
            var repositoryMock = new Mock<IDinoRepository>();
            repositoryMock.Setup(r => r.AddSpecies(It.IsAny<Species[]>()));
            repositoryMock.Setup(r => r.AddDinosaurs(It.IsAny<Dinosaur[]>()));

            var paths = new[] { "path" };
            var imageProvidermock = new Mock<IImageProvider>();
            imageProvidermock
                .Setup(pr => pr.GetPaths())
                .Returns(paths);

            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<BogusGender>(It.IsAny<Gender>()))
                .Returns((Gender source) => It.IsAny<BogusGender>());

            _generator = new DataGenerator(repositoryMock.Object, imageProvidermock.Object, mapperMock.Object);
        }

        [Test]
        public void DataGenerator_Throws_IfSpeciesCountIsNegative()
        {
            async Task Func() => await _generator.Generate(-1, 1);
            Assert.ThrowsAsync<GenerationException>(Func);
        }

        [Test]
        public void DataGenerator_Throws_IfDinosaursCountIsNegative()
        {
            async Task Func() => await _generator.Generate(1, -1);
            Assert.ThrowsAsync<GenerationException>(Func);
        }
        
        [Test]
        public void DataGenerator_Throws_IfSpeciesCountIsZeroAndDinosaursCountIsPositive()
        {
            async Task Func() => await _generator.Generate(0, 1);
            Assert.ThrowsAsync<GenerationException>(Func);
        }

        [Test]
        public async Task DataGenerator_Generates_NotNullSpeciesCollection_Always()
        {
            var res = await _generator.Generate(0, 0);
            Assert.NotNull(res.Species);
        }
        
        [Test]
        public async Task DataGenerator_Generates_NotNullDinosaursCollection_Always()
        {
            var res = await _generator.Generate(0, 0);
            Assert.NotNull(res.Dinosaurs);
        }

        [Test]
        public async Task DataGenerator_Generates_ExpectedCountOfSpecies_Always()
        {
            const int speciesCount = 10;
            const int dinosaursCount = 100;
            var res = await _generator.Generate(speciesCount, dinosaursCount);
            Assert.AreEqual(speciesCount, res.Species.Count);
        }

        [Test]
        public async Task DataGenerator_Generates_ExpectedCountOfDinosaurs_Always()
        {
            const int speciesCount = 10;
            const int dinosaursCount = 100;
            var res = await _generator.Generate(speciesCount, dinosaursCount);
            Assert.AreEqual(dinosaursCount, res.Dinosaurs.Count);
        }
    }
}