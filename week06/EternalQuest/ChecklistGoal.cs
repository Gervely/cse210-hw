public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
        {
            return GetPoints() + _bonusPoints;
        }
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        string status = _currentCount >= _targetCount ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_targetCount},{_bonusPoints},{_currentCount}";
    }
}
