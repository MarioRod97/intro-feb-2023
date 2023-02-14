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

        // Integration test - usually has many steps.
        await host.Scenario(api =>
        {
            api.Get.Url("/status");

            // 200 status code.
            api.StatusCodeShouldBeOk();
        });
    }

    [Fact]
    public async Task TheContactIsAPhoneNumberDuringBusinessHours()
    {
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var stubbedSystemTime = new Mock<ISystemTime>();

            stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.BeforeCutOffTime);
            
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(stubbedSystemTime.Object);
            });
        });

        // Integration test - usually has many steps.
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/status");
        });

        var responseMessage = response.ReadAsJson<GetStatusResponse>();
        var expectedResponse = new GetStatusResponse("All Good", "555 555-5555");
        
        Assert.NotNull(responseMessage);
        Assert.Equal(expectedResponse, responseMessage);
    }

    [Fact]
    public async Task TheContactIsAnEmailAfterBusinessHours()
    {
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var stubbedSystemTime = new Mock<ISystemTime>();

            stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.AfterCutoffTime);
            
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