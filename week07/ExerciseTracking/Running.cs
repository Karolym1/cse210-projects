using System;

public class Running : Activity
{
    private double _distance; // miles

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // miles per hour
        return (_distance / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // minutes per mile
        return GetMinutes() / _distance;
    }
}

