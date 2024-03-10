namespace Ekid.Activities;

public class InMemoryActivityRepository
{
    private readonly List<Activity> _activities = new();

    public async Task SaveAsync(Activity activity)
    {
        var current = await GetAsync(activity.Id);
        if (current != null)
        {
            _activities.Remove(current);
        }
        _activities.Add(activity);
    }

    public Task<Activity?> GetAsync(Guid id) 
        => Task.FromResult(_activities.FirstOrDefault(x => x.Id == id));
}