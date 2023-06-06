namespace Persistence.Dao;

public class ArticlePriceDao
{
    public required decimal VatRate { get; set; }
    public required decimal VatAmount { get; set; }
    public required decimal NonVatAmount { get; set; }
}
