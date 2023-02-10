
namespace StringCalculator;

public class StringCalculator
{
    private ILogger _logger;
    private IWebService _webservice;

    public StringCalculator(ILogger logger, IWebService webservice)
    {
        _logger = logger;
        _webservice = webservice;
    }

    public int Add(string numbers)
    {
        int answer = 0;
        
        if (numbers == "")
        {
            answer = 0;
        }
        else
        {
            answer = numbers.Split(',', '\n')
            .Select(int.Parse)
            .Sum();
        }

        try
        {
            _logger.Write(answer.ToString());
        }
        catch (LoggerException ex)
        {

            _webservice.NotifyOfFailedLogging(ex.Message);
        }

        return answer;
    }
}

public interface ILogger
{
    void Write(string message);
}

public interface IWebService
{
    void NotifyOfFailedLogging(string message);
}

public class LoggerException : ApplicationException
{
    public string Message { get; private set; } = "";

    public LoggerException(string message) {
        Message = message;
    }
}
