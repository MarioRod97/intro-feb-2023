using Moq;

namespace StringCalculator;

public class StringCalculatorInteractionTests
{
    [Theory]
    [InlineData("1,2", "3")]
    public void AnswersAreLoggedToLogger(string numbers, string expected)
    {
        // Given
        var mockedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(mockedLogger.Object, mockedWebService.Object);

        // When
        calculator.Add(numbers);

        // Then
        mockedLogger.Verify(logger => logger.Write(expected), Times.Once);
        mockedWebService.Verify(logger => logger.NotifyOfFailedLogging(It.IsAny<string>()), Times.Never());
    }

    [Theory]
    [InlineData("Blammer!")]
    [InlineData("Taco Bell!")]
    public void WhenLoggerBlowsUpWebServiceIsCalled(string expected)
    {
        // Given
        var stubbedLogger = new Mock<ILogger>();
        stubbedLogger.Setup(m => m.Write(It.IsAny<string>())).Throws(new LoggerException(expected));
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

        // When
        calculator.Add("1");

        // Then
        mockedWebService.Verify(mw => mw.NotifyOfFailedLogging(expected));
    }
}
