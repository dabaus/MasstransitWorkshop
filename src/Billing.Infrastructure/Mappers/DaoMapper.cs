using Billing.Application.ValueObjects;
using Billing.Domain.Bussines;
using Domain.Bussines;
using Persistence.Dao;

namespace Billing.Infrastructure.Mappers;

public class DaoMapper : IDaoMapper
{
    public Order OrderDao2Domain(OrderDao dao)
    {
        var order = new Order()
        {
            OrderId = new OrderId(dao.Id),
            CurrencyCode = new CurrencyCode(dao.CurrencyCode),
            OrderArticles = dao.Articles.Select(OrderArticleDao2Domain).ToList(),
            OrderNumber = dao.OrderNumber,
            CustomerId = new CustomerId(dao.CustomerId),
        };
        return order;
    }

    public OrderArticle OrderArticleDao2Domain(OrderArticleDao dao)
    {
        var article = new OrderArticle
        {
            SKU = dao.Sku,
            Name = dao.Name,
            Quantity = dao.Quantity,
            Unit = dao.Unit,
            TotalPrice = ArticlePriceDao2Domain(dao.TotalPrice)
        };
        return article;
    }

    public ArticlePrice ArticlePriceDao2Domain(ArticlePriceDao dao)
    {
        var price = new ArticlePrice()
        {
            VatAmount = dao.VatAmount,
            NonVatAmount = dao.NonVatAmount,
            VatRate = dao.VatRate
        };
        return price;
    }

    public OrderDao DomainOrder2Dao(Order order)
    {
        var orderDao = new OrderDao()
        {
            Id = order.OrderId.Value,
            OrderNumber = order.OrderNumber,
            Articles = order.OrderArticles.Select(DomainOrderArticle2Dao).ToList(),
            CurrencyCode = order.CurrencyCode.Value,
            CustomerId = order.CustomerId.Value,
        };
        return orderDao;
    }

    public OrderArticleDao DomainOrderArticle2Dao(OrderArticle article)
    {
        return new OrderArticleDao
        {
            TotalPrice = DomainArticlePrice2Dao(article.TotalPrice),
            Name = article.Name,
            Quantity =article.Quantity,
            Sku = article.SKU,
            Unit = article.Unit
        };
    }

    public ArticlePriceDao DomainArticlePrice2Dao(ArticlePrice price)
    {
        return new ArticlePriceDao()
        {
            VatAmount = price.VatAmount,
            NonVatAmount = price.NonVatAmount,
            VatRate = price.VatRate
        };
    }
    
    
}