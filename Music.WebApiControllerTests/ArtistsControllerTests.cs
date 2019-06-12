using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.WebApiControllerTests
{
    [TestClass]
    public class ArtistsControllerTests
    {
        readonly Mock<IArtistService> _service;
        readonly ArtistsController _controller;

        public ArtistsControllerTests()
        {
            _service = new Mock<IArtistService>();
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestArtists());
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestArtists());
            _controller = new ArtistsController(_service.Object);
        }

        [TestMethod]
        public async Task GetAllArtistsAsync_ShouldReturnNotNull()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();
            List<Artist> artists = result.ToList();
            //Assert
            Assert.IsNotNull(artists);
            Assert.AreEqual(artists.Count, GetTestArtists().ToList().Count);
        }

        [TestMethod]
        public async Task GetAllArtistsAsync_ShouldReturnAllArtists()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();

            //Assert
            Assert.IsNotNull(result);
        }

        private IEnumerable<Artist> GetTestArtists()
        {
            var testProducts = new List<Artist>();
            testProducts.Add(new Artist { Name = "Demo1" });
            testProducts.Add(new Artist { Name = "Demo2" });
            testProducts.Add(new Artist { Name = "Demo3" });
            testProducts.Add(new Artist { Name = "Demo4" });

            return testProducts;
        }
    }
}
