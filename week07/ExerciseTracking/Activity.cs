using System;

public abstract class Activity
{
    private string _date;
    private int _minutes;

    protected Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        // Example:
        // 03 Nov 2022 Running (30 min) - Distance 3.0 miles, Speed 6.0 mph, Pace 10.0 min per mile
        return $"{_date} {GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace {GetPace():0.0} min per mile";
    }
}

