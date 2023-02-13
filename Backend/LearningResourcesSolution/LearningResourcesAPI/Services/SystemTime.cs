namespace LearningResourcesApi.Services;

public class SystemTime : ISystemTime
{
    public DateTimeOffset GetCurrent() => DateTimeOffset.Now;
}


public interface ISystemTime
{
    DateTimeOffset GetCurrent();
}