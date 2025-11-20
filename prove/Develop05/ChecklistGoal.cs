public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _timesCompleted;
    private int _completionsNeeded;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int bonusPoints,
        int completionsNeeded,
        int timesCompleted = 0)
        : base(name, description, points)
    {
        _bonusPoints = bonusPoints;
        _completionsNeeded = completionsNeeded;
        _timesCompleted = timesCompleted;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }
    public int GetCompletionsNeeded()
    {
        return _completionsNeeded;
    }

    public override void RecordEvent(ref int points)
    {
        _timesCompleted ++;
        points += _points;
        if(IsComplete())
        {
            points += _bonusPoints;
        }
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _completionsNeeded;
    }
    public override string ToDataString()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonusPoints}|{_completionsNeeded}|{_timesCompleted}";
    }
}
