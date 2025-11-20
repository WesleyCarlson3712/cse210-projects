public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent(ref int points)
    {
        points += _points;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals never complete
    }
    public override string ToDataString()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}
