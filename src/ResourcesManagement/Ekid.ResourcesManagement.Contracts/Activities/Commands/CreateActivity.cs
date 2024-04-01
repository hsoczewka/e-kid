using Ekid.Infrastructure.Messaging;

namespace Ekid.ResourcesManagement.Contracts.Activities.Commands;

public class CreateActivity : ICommand
{
    public CreateActivity(string description, string type, int duration, decimal price)
    {
        Description = description;
        Type = type;
        Duration = duration;
        Price = price;
    }

    public string Description { get; }
    public string Type { get; }
    public int Duration { get; }
    public decimal Price { get; }
    
}