using Ekid.Infrastructure.Messaging;

namespace Ekid.Resources.Contracts.Activities.Commands;

public class CreateActivity : ICommand
{
    public CreateActivity(string description, string type, int duration, decimal priceAmount, string priceCurrency)
    {
        Description = description;
        Type = type;
        Duration = duration;
        PriceAmount = priceAmount;
        PriceCurrency = priceCurrency;
    }

    public string Description { get; }
    public string Type { get; }
    public int Duration { get; }
    public decimal PriceAmount { get; }
    public string PriceCurrency { get; }
    
}