public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Always awards points; never completes
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal|name|description|points
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}

