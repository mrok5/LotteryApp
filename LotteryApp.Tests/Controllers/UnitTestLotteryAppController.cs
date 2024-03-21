using LotteryApp.Controllers;
using LotteryApp.Data.Entities;
using LotteryApp.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace LotteryApp.Tests.Controllers
{
    [TestClass]
    public class UnitTestLotteryAppController
    {
        [TestMethod]
        public void ShouldGetDrawReturnOK()
        {
            // Arrange
            var mockRepository = new Mock<IDrawRepository>();
            mockRepository.Setup(x => x.Get(1))
                .Returns(new DrawHistory { Id = 42 });

            var drawsController = new DrawsController(mockRepository.Object);

            // Act
            var result = drawsController.GetDraw(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void ShouldGetDrawReturnNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IDrawRepository>();
            mockRepository.Setup(x => x.Get(1));

            var drawsController = new DrawsController(mockRepository.Object);

            // Act
            var result = drawsController.GetDraw(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void ShouldGetDrawHistoryReturnOK()
        {
            // Arrange
            var mockRepository = new Mock<IDrawRepository>();
            mockRepository.Setup(x => x.GetDrawHistory())
                .Returns(new List<DrawHistory>() { new DrawHistory() });

            var drawsController = new DrawsController(mockRepository.Object);

            // Act
            var result = drawsController.GetDrawHistory();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void ShouldGetDrawHistoryReturnNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IDrawRepository>();
            mockRepository.Setup(x => x.GetDrawHistory());

            var drawsController = new DrawsController(mockRepository.Object);

            // Act
            var result = drawsController.GetDrawHistory();

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void ShouldGetNewDrawReturnOK()
        {
            // Arrange
            var mockRepository = new Mock<IDrawRepository>();
            var drawsController = new DrawsController(mockRepository.Object);

            // Act
            var result = drawsController.NewDraw();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
