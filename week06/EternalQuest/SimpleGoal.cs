using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public void SetComplete(bool status)
    {
        _isComplete = status;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return status + " " + _shortName + " (" + _description + ")";
    }

    public override string GetStringRepresentation()
    {
        return "SimpleGoal:" + _shortName + "," + _description + "," + _points + "," + _isComplete;
    }
}