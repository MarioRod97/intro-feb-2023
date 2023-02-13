namespace LearningResourcesAPI.IntegrationTest;

public class TestData
{
    public static DateTimeOffset BeforeCutOffTime { get; set; } = new DateTimeOffset(1969, 4, 20, 23, 59, 00, TimeSpan.FromHours(-5));
    public static DateTimeOffset AfterCutoffTime { get; set; } = new DateTimeOffset(1969, 4, 20, 14, 00, 00, TimeSpan.FromHours(-5));
}
