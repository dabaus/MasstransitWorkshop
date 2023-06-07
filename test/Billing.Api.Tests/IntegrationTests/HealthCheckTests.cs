using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Billing.Api.Tests;

public class HealthCheckTests : IClassFixture<WebApplicationFactory<Billing.Api.Program>>
{
    private readonly HttpClient _client;
    
    public HealthCheckTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Can_query_healthcheck_and_get_result_ok()
    {
        var response = await _client.GetAsync("/healthchecks");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}