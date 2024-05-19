using Ekid.Infrastructure.Primitives;

namespace Ekid.Resources.Activities;

public record Prices(IList<ProductPrice> ProductPrices)
{
    public static Prices Of(params ProductPrice[] productPrices)
    {
        return new Prices(productPrices);
    }
    
}