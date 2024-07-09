namespace TiredOwl.Domain.Offers;

public class TimeRange : ValueObject
{
    public int EndHour { get; set; }
    public int StartHour { get; set; }

    public static TimeRange Create(int startHour, int endHour) => new TimeRange(startHour, endHour);

    private TimeRange(int startHour, int endHour)
    {
        StartHour = startHour;
        EndHour = endHour;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartHour;
        yield return EndHour;
    }

}