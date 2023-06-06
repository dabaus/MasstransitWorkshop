using Billing.Domain.Bussines;
using Domain.Bussines;
using Persistence.Dao;

namespace Billing.Infrastructure.Mappers;

public interface IDaoMapper
{
    public Order OrderDao2Domain(OrderDao dao);
    public OrderArticle OrderArticleDao2Domain(OrderArticleDao dao);
    public ArticlePrice ArticlePriceDao2Domain(ArticlePriceDao dao);

    public OrderDao DomainOrder2Dao(Order order);
    public OrderArticleDao DomainOrderArticle2Dao(OrderArticle article);
    public ArticlePriceDao DomainArticlePrice2Dao(ArticlePrice price);
}