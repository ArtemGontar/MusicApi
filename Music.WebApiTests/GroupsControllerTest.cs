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
    class GroupsControllerTest
    {
        readonly Mock<IGroupService> _service;
        readonly GroupsController _controller;

        public GroupsControllerTest()
        {
            _service = new Mock<IGroupService>();
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestGroups());
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestGroups());
            _controller = new GroupsController(_service.Object);
        }

        [TestMethod]
        public async Task GetAllGroupsAsync_ShouldReturnNotNull()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();
            List<Group> groups = result.ToList();
            //Assert
            Assert.IsNotNull(groups);
            Assert.AreEqual(groups.Count, GetTestGroups().ToList().Count);
        }

        [TestMethod]
        public async Task GetAllGroupsAsync_ShouldReturnAllGroups()
        {
            //Arrange

            //Act
            var result = await _controller.GetAllAsync();

            //Assert
            Assert.IsNotNull(result);
        }

        private IEnumerable<Group> GetTestGroups()
        {
            var testProducts = new List<Group>();
            testProducts.Add(new Group { GroupName = "Demo1" });
            testProducts.Add(new Group { GroupName = "Demo2" });
            testProducts.Add(new Group { GroupName = "Demo3" });
            testProducts.Add(new Group { GroupName = "Demo4" });

            return testProducts;
        }
    }
}
