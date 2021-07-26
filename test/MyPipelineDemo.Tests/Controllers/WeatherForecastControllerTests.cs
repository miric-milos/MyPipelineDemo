using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MyPipelineDemo.Controllers.Tests
{
    public class WeatherForecastControllerTests
    {
        [Theory(DisplayName = "Should throw Exception if index was out of bounds")]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void Get_ShouldThrowException(int value)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.Get(value));
        }
    }
}