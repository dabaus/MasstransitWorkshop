namespace Persistence.Dao;

public class OrderArticleDao
{
    public required string Sku { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required string Unit { get; set; } 
    public required ArticlePriceDao TotalPrice { get; set; }
};
