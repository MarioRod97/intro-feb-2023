using LearningResourcesApi.Controllers;
using LearningResourcesApi.Services;
using LearningResourcesAPI.IntegrationTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace LearningResourcesApi.IntegrationTests;

public class StatusResourceTests
{
    [Fact]
    public async Task TheStatusResource()
    {
        await using var host = await AlbaHost.For<Program>();

        await host.Scenario(api => // Integration test - usually has many steps.
        {
            api.Get.Url("/status");
            api.StatusCodeShouldBeOk(); // 200 status code.

        });

    }

    [Fact]
    public async Task TheContactIsAPhoneNumberDuringBusinessHours()
    {
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var stubbedSystemTime = new Mock<ISystemTime>();

            stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.BeforeCutOffTime);
            //var dateToReturn = new DateTimeOffset()
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(stubbedSystemTime.Object);
            });
        });

        var response = await host.Scenario(api => // Integration test - usually has many steps.
        {
            api.Get.Url("/status");
        });

        var responseMessage = response.ReadAsJson<GetStatusResponse>();
        Assert.NotNull(responseMessage);
        Assert.Equal("All Good", responseMessage.Message);
        Assert.Equal("555 555-5555", responseMessage.Contact);
    }

    [Fact]
    public async Task TheContactIsAnEmailAfterBusinessHours()
    {
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var stubbedSystemTime = new Mock<ISystemTime>();

            stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.AfterCutoffTime);
            //var dateToReturn = new DateTimeOffset()
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(stubbedSystemTime.Object);
            });
        });

        var response = await host.Scenario(api => // Integration test - usually has many steps.
        {
            api.Get.Url("/status");
        });

        var responseMessage = response.ReadAsJson<GetStatusResponse>();
        Assert.NotNull(responseMessage);
        Assert.Equal("All Good", responseMessage.Message);
        Assert.Equal("bob@aol.com", responseMessage.Contact);
    }
}