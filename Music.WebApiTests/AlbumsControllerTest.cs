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
    class AlbumsControllerTest
    {
        readonly Mock<IAlbumService> _service;
        readonly AlbumsController _controller;

        public AlbumsControllerTest()
        {
            _service = new Mock<IAlbumService>();
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestAlbums());
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestAlbums());
            _controller = new AlbumsController(_service.Object);
        }

        [TestMethod]
        public async Task GetAllAlbumsAsync_ShouldReturnNotNull()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();
            List<Album> albums = result.ToList();
            //Assert
            Assert.IsNotNull(albums);
            Assert.AreEqual(albums.Count, GetTestAlbums().ToList().Count);
        }

        [TestMethod]
        public async Task GetAllAlbumsAsync_ShouldReturnAllAlbums()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();

            //Assert
            Assert.IsNotNull(result);
        }

        private IEnumerable<Album> GetTestAlbums()
        {
            var testProducts = new List<Album>();
            testProducts.Add(new Album { Name = "Demo1" });
            testProducts.Add(new Album { Name = "Demo2" });
            testProducts.Add(new Album { Name = "Demo3" });
            testProducts.Add(new Album { Name = "Demo4" });

            return testProducts;
        }
    }
}
