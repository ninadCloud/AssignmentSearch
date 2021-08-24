using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TestSearch.Controllers;
using TestSearch.Models;
using TestSearch.Interfaces;
using System.Web.Mvc;

namespace TestSearch.Tests.UnitTests
{
    [TestClass]
    class HomeControllerTests
    {
        private HomeController controller;
        private Mock<ISearchEngineService> searchEngineServiceMock;

        [TestMethod]
        public void TestMethod2()
        {
            var engineList = new List<SearchEngineModel>
            {
                new SearchEngineModel
                {
                    Id = 1,
                    Name = "Google",
                    Url = "Https://developer.google.com"
                },
                new SearchEngineModel
                {
                    Id = 2,
                    Name = "Bing",
                    Url = "Https://developer.bing.com"
                },
            };

            searchEngineServiceMock = new Mock<ISearchEngineService>();
            searchEngineServiceMock.Setup(p => p.GetAllSearchEngines()).Returns(engineList);
            controller = new HomeController(searchEngineServiceMock.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
    }
}
