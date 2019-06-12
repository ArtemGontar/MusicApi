using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.WebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.WebApiTests
{
    [TestClass]
    class SongsControllerTest
    {
        readonly Mock<ISongService> _service;
        readonly SongsController _controller;

        public SongsControllerTest()
        {
            _service = new Mock<ISongService>();
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestSongs());
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestSongs());
            _controller = new SongsController(_service.Object);
        }

        [TestMethod]
        public async Task GetAllSongsAsync_ShouldReturnNotNull()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();
            List<Song> songs = result.ToList();
            //Assert
            Assert.IsNotNull(songs);
            Assert.AreEqual(songs.Count, GetTestSongs().ToList().Count);
        }

        [TestMethod]
        public async Task GetAllSongsAsync_ShouldReturnAllAlbums()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();

            //Assert
            Assert.IsNotNull(result);
        }

        private IEnumerable<Song> GetTestSongs()
        {
            var testProducts = new List<Song>();
            testProducts.Add(new Song { Name = "Demo1" });
            testProducts.Add(new Song { Name = "Demo2" });
            testProducts.Add(new Song { Name = "Demo3" });
            testProducts.Add(new Song { Name = "Demo4" });

            return testProducts;
        }
    }
}
