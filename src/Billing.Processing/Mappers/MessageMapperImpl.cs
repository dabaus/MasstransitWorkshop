using Billing.Domain.Commands;
using Billing.MessageContracts.Commands;
using Billing.MessageContracts.Dto;
using Domain.Bussines;

namespace Billing.Processing.Mappers;

public class MessageMapperImpl : IMessageMapper
{
    public ICreateOrderCommand Msg2Command(CreateOrderCommandMsg msg)
    {
        return new CreateOrderCommand()
        {
            OrderId = msg.OrderId,
            CustomerId = msg.CustomerId,
            CurrencyCode = msg.CurrencyCode,
            OrderArticles = msg.OrderArticles.Select(Msg2DomainOrderArticle).ToList()
        };
    }

    private OrderArticle Msg2DomainOrderArticle(OrderArticleDtoMsg msg)
    {
        return new OrderArticle()
        {
            Name = msg.Name,
            Quantity = msg.Quantity,
            SKU = msg.SKU,
            Unit = msg.Unit,
            TotalPrice = Msg2DomainArticlePrice(msg.TotalPrice)
        };
    }

    private ArticlePrice Msg2DomainArticlePrice(ArticlePriceDtoMsg msg)
    {
        return new ArticlePrice()
        {
            NonVatAmount = msg.NonVatAmount,
            VatAmount = msg.VatAmount,
            VatRate = msg.VatRate
        };
    }
    public class CreateOrderCommand : ICreateOrderCommand
    {
        public required Guid OrderId { get; set; }
        public required string CurrencyCode { get; set; }
        public required Guid CustomerId { get; set; }
        public required List<OrderArticle> OrderArticles { get; set; }
    }
   
}