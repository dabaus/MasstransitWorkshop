namespace Domain.Bussines;

public class OrderArticle
{
    public required string SKU { get; set; } 
    public required string Name  { get; set; } 
    public required  int Quantity  { get; set; } 
    public required string Unit  { get; set; } 
    public required ArticlePrice TotalPrice  { get; set; } 
}