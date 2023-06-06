using Billing.Api.Dto;
using Billing.Api.Requests;
using Billing.Application.Commands;
using Billing.Domain.Bussines;
using Billing.Domain.Commands;
using Billing.Domain.Queries;
using Domain.Bussines;

namespace Billing.Api.Mappers;

public interface IDtoMapper
{
    public OrderDto OrderToDto(Order order);
    public OrderArticleDto OrderArticleToDto(OrderArticle article);

    public ArticlePriceDto ArticlePriceToDto(ArticlePrice articlePrice);

    public OrderArticle OrderArticleDtoToDomain(OrderArticleDto dto);

    public ArticlePrice ArticlePriceDtoToDomain(ArticlePriceDto price);
}