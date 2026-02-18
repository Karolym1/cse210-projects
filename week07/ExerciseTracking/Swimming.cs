using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Convert meters to miles
        double meters = _laps * 50;
        return meters / 1609.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}

