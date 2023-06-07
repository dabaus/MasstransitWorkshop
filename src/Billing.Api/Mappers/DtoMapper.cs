using Billing.Api.Dto;
using Billing.Api.Requests;
using Billing.Api.Responses;
using Billing.Application.Commands;
using Billing.Application.Queries;
using Billing.Domain.Bussines;
using Billing.Domain.Commands;
using Billing.Domain.Queries;
using Domain.Bussines;

namespace Billing.Api.Mappers;

public class DtoMapper : IDtoMapper
{

    public OrderDto OrderToDto(Order order)
    {
        return new OrderDto()
        {
            CurrencyCode = order.CurrencyCode.Value,
            CustomerId = order.CustomerId.Value,
            OrderId = order.OrderId.Value,
            OrderNumber = order.OrderNumber,
            OrderArticles = order.OrderArticles.Select(x => OrderArticleToDto(x)).ToList()
        };
    }

    public OrderArticleDto OrderArticleToDto(OrderArticle article)
    {
        return new OrderArticleDto()
        {
            Name = article.Name,
            Quantity = article.Quantity,
            SKU = article.SKU,
            TotalPrice = ArticlePriceToDto(article.TotalPrice),
            Unit = article.Unit
        };
    }

    public ArticlePriceDto ArticlePriceToDto(ArticlePrice articlePrice)
    {
        return new ArticlePriceDto()
        {
            NonVatAmount = articlePrice.NonVatAmount,
            VatAmount = articlePrice.VatAmount,
            VatRate = articlePrice.VatRate
        };
    }

    public OrderArticle OrderArticleDtoToDomain(OrderArticleDto dto)
    {
        return new OrderArticle()
        {
            Name = dto.Name,
            Quantity = dto.Quantity,
            SKU = dto.SKU,
            Unit = dto.Unit,
            TotalPrice = ArticlePriceDtoToDomain(dto.TotalPrice)
        };
    }

    public ArticlePrice ArticlePriceDtoToDomain(ArticlePriceDto price)
    {
        return new ArticlePrice()
        {
            NonVatAmount = price.NonVatAmount,
            VatAmount = price.VatAmount,
            VatRate = price.VatRate
        };
    }
}

