namespace Ekid.Infrastructure.Primitives;

public class ProductPrice
{
    public Money Price { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}