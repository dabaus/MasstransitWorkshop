using Domain.Bussines;

namespace Billing.Application.Validation;

public class ValidationUtils
{
    

    public static void ValidateOrderNumber(string OrderNumber)
    {
        if (string.IsNullOrEmpty(OrderNumber))
        {
            throw new Exception($"Invalid order number {OrderNumber}");
        }
    }

    public static void ValidateOrderArticle(OrderArticle orderArticle)
    {
        if (orderArticle.Quantity == 0)
        {
            throw new Exception("Invalid quantity");
        }
        if (string.IsNullOrEmpty(orderArticle.SKU))
        {
            throw new Exception("SKU cannot be empty");
        }
        if (string.IsNullOrEmpty(orderArticle.Name))
        {
            throw new Exception("Name cannot be empty");
        }
        if (string.IsNullOrEmpty(orderArticle.Unit))
        {
            throw new Exception("Unit cannot be empty");
        }
        ValidationUtils.ValidateArticlePrice(orderArticle.TotalPrice);
    }

    public static void ValidateArticlePrice(ArticlePrice articlePrice)
    {
        if(articlePrice.VatRate > 100 || articlePrice.VatRate < 0)
        {
            throw new Exception($"Invalid vat rate {articlePrice.VatRate}");
        }
    }
    
    
}