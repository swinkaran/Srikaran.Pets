using NUnit.Framework;
using Srikaran.ThePets.DTO;
using Srikaran.ThePets.Services.QueriesService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Srikaran.ThePets.Tests
{
    [TestFixture]
    public class PetQueriesServiceTests
    {
        private readonly IQueriesService _IQueriesService;
        private IList<PetsByOwnersGender> OwnerPets;

        public PetQueriesServiceTests()
        {
            //Mock data file
            _IQueriesService = new QueriesService(@"Pet.json");
        }

        [SetUp]
        public async System.Threading.Tasks.Task SetupAsync()
        {
            OwnerPets = (IList<PetsByOwnersGender>)await _IQueriesService.GetPetsByTypeAsync("cat");
        }

        [Test]
        public void ShouldNotHaveEmptyPets() // Pet names should not be empty
        {
            var sut = OwnerPets[0].Pets;
            Assert.That(sut, Is.All.Not.Empty);
        }

        [Test]
        public void ShouldHaveTwoValues() // Male and Female
        {
            var counts = OwnerPets.Count;
            Assert.That(counts, Is.EqualTo(2));
        }

        [Test]
        public void ShouldHaveMaleAndFemale()
        {
            var sut = OwnerPets[0].Gender;
            Assert.That(sut, Is.EqualTo("Male"));
        }

        [Test]
        public void ShouldBeOrderedAsc()
        {
            var sut = OwnerPets[0].Pets;
            Assert.That(sut, Is.Ordered);
        }
    }
}
