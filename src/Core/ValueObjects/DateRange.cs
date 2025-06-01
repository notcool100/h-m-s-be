namespace Core.ValueObjects;
public class DateRange
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateRange(DateTime start, DateTime end)
    {
        if (end < start) throw new Exception("Invalid range");
        Start = start;
        End = end;
    }
}
