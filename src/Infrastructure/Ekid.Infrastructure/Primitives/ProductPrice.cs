namespace Ekid.Infrastructure.Primitives;

public class ProductPrice
{
    public ProductPrice(Money price, DateTime validFrom, DateTime? validTo)
    {
        Price = price;
        ValidFrom = validFrom;
        ValidTo = validTo;
    }

    public Money Price { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}