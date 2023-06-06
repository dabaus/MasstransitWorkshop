namespace Billing.Api.Dto;

public class OrderArticleDto
{
    public required string SKU { get; set; } 
    public required string Name  { get; set; } 
    public required  int Quantity  { get; set; } 
    public required string Unit  { get; set; } 
    public required ArticlePriceDto TotalPrice  { get; set; } 
}