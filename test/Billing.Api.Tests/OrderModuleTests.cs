

using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Billing.Api.Dto;
using Billing.Api.Extensions;
using Billing.Api.Requests;
using Billing.Api.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Xunit;

namespace Billing.Api.Tests;

public class OrderModuleTests : IClassFixture<WebApplicationFactory<Billing.Api.Program>>
{

    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions().SetCustomOptions();
    
    public OrderModuleTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Can_create_order_and_get_result()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var order = OrderUtils.CreateOrderWithId(orderId);
        
        // Act 
        var requestContent = JsonContent.Create(order);
        var result = await _client.PostAsync("/orders",  requestContent);
        var responseContent = await result.Content.ReadFromJsonAsync<CreateOrderResponse>(options:_serializerOptions);
        
        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        responseContent.Should().NotBeNull();
        responseContent!.OrderId.Should().Be(orderId);
    }

    [Fact]
    public async Task Can_query_order_and_match_created()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var order = OrderUtils.CreateOrderWithId(orderId);
        
        // Act 
        var requestContent = JsonContent.Create(order);
        await _client.PostAsync("/orders",  requestContent);

        var result = await _client.GetAsync($"/orders/{orderId}");
        var ct = await result.Content.ReadAsStringAsync();
        
        var content = (await result.Content.ReadFromJsonAsync<FindOrderResponse>(options: _serializerOptions));

        // Assert
        content.Should().NotBeNull();
        var resultOrder = content!.Order;
        resultOrder.OrderId.Should().Be(orderId);
        resultOrder.CurrencyCode.Should().Be(order.CurrencyCode);
        resultOrder.CustomerId.Should().Be(order.CustomerId);
        resultOrder.OrderNumber.Should().NotBeNullOrEmpty();
        resultOrder.OrderArticles.Should().BeEquivalentTo(order.OrderArticles);

    }
}