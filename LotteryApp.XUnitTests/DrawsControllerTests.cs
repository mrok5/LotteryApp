using LotteryApp.Controllers;
using LotteryApp.Data.Entities;
using LotteryApp.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LotteryApp.Tests
{
    public class DrawsControllerTests
    {
        private readonly Mock<IDrawRepository> _drawRepositoryMock;
        private readonly DrawsController _controller;

        public DrawsControllerTests()
        {
            _drawRepositoryMock = new Mock<IDrawRepository>();
            _controller = new DrawsController(_drawRepositoryMock.Object);
        }

        [Fact]
        public void GetDraw_ReturnsOkResult_WhenDrawExists()
        {
            // Arrange
            var drawId = 1;
            var expectedDraw = new DrawHistory { Id = drawId, Draw = "1, 2, 3" };

            _drawRepositoryMock.Setup(repo => repo.Get(drawId)).Returns(expectedDraw);

            // Act
            var result = _controller.GetDraw(drawId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualDraw = Assert.IsType<DrawHistory>(okResult.Value);
            Assert.Equal(expectedDraw.Id, actualDraw.Id);
            Assert.Equal(expectedDraw.Draw, actualDraw.Draw);
        }

        [Fact]
        public void GetDraw_ReturnsNotFound_WhenDrawDoesNotExist()
        {
            // Arrange
            var drawId = 2;
            _drawRepositoryMock.Setup(repo => repo.Get(drawId)).Returns((DrawHistory)null);

            // Act
            var result = _controller.GetDraw(drawId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetDrawHistory_ReturnsOkResult_WhenDrawHistoryExists()
        {
            // Arrange
            var expectedDrawHistory = new List<DrawHistory>
            {
                new DrawHistory { Id = 1, DrawDateTime = DateTime.Now, Draw = "1, 2, 3" },
                new DrawHistory { Id = 2, DrawDateTime = DateTime.Now, Draw = "4, 5, 6"}
            };
            _drawRepositoryMock.Setup(repo => repo.GetDrawHistory()).Returns(expectedDrawHistory);

            // Act
            var result = _controller.GetDrawHistory();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualDrawHistory = Assert.IsType<List<DrawHistory>>(okResult.Value);
            Assert.Equal(expectedDrawHistory.Count, actualDrawHistory.Count);
            Assert.Equal(expectedDrawHistory.First().Draw, actualDrawHistory.First().Draw);
        }

    }
}
