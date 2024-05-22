using Ekid.Infrastructure.Identity.Authorization;
using Ekid.Infrastructure.Messaging;
using Ekid.Resources.Contracts.Security;

namespace Ekid.Resources.Contracts.Activities.Commands;

[HasPermission(Permissions.ManageActivityId)]
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