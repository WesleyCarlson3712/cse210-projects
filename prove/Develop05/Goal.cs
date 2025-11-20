public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent(ref int points);
    public abstract bool IsComplete();
    public abstract string ToDataString();

    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
}
