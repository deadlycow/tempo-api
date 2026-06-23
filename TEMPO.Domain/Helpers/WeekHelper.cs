namespace TEMPO.Domain.Helpers;

public static class WeekHelper
{
    public static DateOnly GetWeekStart(DateOnly date)
    {
        var diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;

        return date.AddDays(-diff);
    }
}