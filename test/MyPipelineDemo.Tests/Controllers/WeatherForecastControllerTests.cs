using System;
using Microsoft.AspNetCore.Mvc;
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

        [Fact(DisplayName = "Should return a single summary with provided index")]
        public void Get_ShouldReturnSummary()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            var expected = "Bracing";
            
            // Act
            var actual = controller.Get(12) as OkObjectResult;

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }
    }
}