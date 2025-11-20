public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override void RecordEvent(ref int points)
    {
        _completed = true;
        points += _points;
    }

    public override bool IsComplete()
    {
        return _completed;
    }
    public override string ToDataString()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_completed}";
    }

}
