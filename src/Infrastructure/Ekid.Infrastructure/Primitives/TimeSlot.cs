namespace Ekid.Infrastructure.Primitives;

public class TimeSlot : IEquatable<TimeSlot>
{
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }

    public TimeSlot(DateTime startTime, DateTime endTime)
    {
        if (endTime <= startTime)
        {
            throw new ArgumentException("End time must be after start time.");
        }

        StartTime = startTime;
        EndTime = endTime;
    }

    public bool OverlapsWith(TimeSlot other)
    {
        return StartTime < other.EndTime && other.StartTime < EndTime;
    }

    public bool Equals(TimeSlot other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return StartTime.Equals(other.StartTime) && EndTime.Equals(other.EndTime);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as TimeSlot);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(StartTime, EndTime);
    }
}
