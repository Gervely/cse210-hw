using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");

            CheckLevelUp();
        }
    }

    private void CheckLevelUp()
    {
        int threshold = _level * 1000;
        if (_score >= threshold)
        {
            _level++;
            Console.WriteLine($"🎉 Congratulations! You leveled up to Level {_level}!");
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
        }
    }

    public int GetGoalCount()
    {
        return _goals.Count;
    }

    public void ShowDetailedStats()
    {
        Console.WriteLine($"\n📊 Detailed Statistics 📊");
        Console.WriteLine($"Total Score: {_score} points");
        Console.WriteLine($"Current Level: {_level}");
        Console.WriteLine($"Points to next level: {_level * 1000 - _score}");
        Console.WriteLine($"Total Goals: {_goals.Count}");

        int completedSimple = 0;
        int totalChecklist = 0;
        int completedChecklist = 0;

        foreach (Goal g in _goals)
        {
            if (g is SimpleGoal sg && sg.IsComplete())
                completedSimple++;
            else if (g is ChecklistGoal cg)
            {
                totalChecklist++;
                if (cg.GetDetailsString().Contains("[X]"))
                    completedChecklist++;
            }
        }

        Console.WriteLine($"Completed Simple Goals: {completedSimple}");
        Console.WriteLine($"Completed Checklist Goals: {completedChecklist}/{totalChecklist}");

        if (_goals.Count > 0)
        {
            double completionRate = ((double)(completedSimple + completedChecklist) / _goals.Count) * 100;
            Console.WriteLine($"Overall Completion Rate: {completionRate:F1}%");
        }

        // Achievement badges
        if (_score >= 100) Console.WriteLine("🏆 Achievement Unlocked: Century Club!");
        if (_level >= 5) Console.WriteLine("⭐ Achievement Unlocked: Goal Master!");
        if (completedChecklist >= 3) Console.WriteLine("🎯 Achievement Unlocked: Checklist Champion!");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);
            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _goals.Clear();

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] details = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4])));
            }
        }
    }
}
