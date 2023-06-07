using AutoFixture.Xunit2;
using Billing.Application.ValueObjects;
using Billing.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace Billing.Api.Tests.UnitTests;

public class ValueObjectTests
{
    [Fact]
    public void Can_crete_CurrencyCode_for_valid_codes()
    {
        // Arrange, Act
        var currencyCode1 = new CurrencyCode("SEK");
        var currencyCode2 = new CurrencyCode("usd");
        var currencyCode3 = new CurrencyCode("EUR");
        
        // Assert
        currencyCode1.Value.Should().Be("SEK");
        currencyCode2.Value.Should().Be("USD");
        currencyCode3.Value.Should().Be("EUR");
    }
    
    [Theory, AutoData]
    public void Can_not_crete_CurrencyCode_for_invalid_code(string random)
    {
        Assert.Throws<InvalidValueException>(() =>
        { 
            new CurrencyCode(random);
        });
    }
    
    [Theory, AutoData]
    public void Can_crete_orderId_for_valid_ids(Guid id)
    {
        // Arrange, Act
        var orderId = new OrderId(id.ToString());
        var orderId2 = new OrderId(id);
        
        // Assert
        orderId.Value.Should().Be(id);
        orderId2.Value.Should().Be(id);
    }

    [Theory, AutoData]
    public void Can_not_create_orderId_for_invalid_ids(string random)
    {
        Assert.Throws<InvalidValueException>(() =>
        { 
            new OrderId(random);
        });
    }
    
    [Theory, AutoData]
    public void Can_crete_customerId_for_valid_ids(Guid id)
    {
        // Arrange, Act
        var customerId = new CustomerId(id.ToString());
        var customerId2 = new CustomerId(id);
        
        // Assert
        customerId.Value.Should().Be(id);
        customerId2.Value.Should().Be(id);
    }

    [Theory, AutoData]
    public void Can_not_create_customerId_for_invalid_ids(string random)
    {
        Assert.Throws<InvalidValueException>(() =>
        { 
            new CustomerId(random);
        });
    }
        
}