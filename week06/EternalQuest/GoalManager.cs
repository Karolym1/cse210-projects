using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {_score} points. (Level {_level})");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
            else if (choice == "6") break;
            else
            {
                Console.WriteLine("Invalid choice.");
                Pause();
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int type = ReadInt("Which type of goal would you like to create? ");

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = ReadInt("What is the amount of points associated with this goal? ");

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }

        Pause();
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Pause();
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found. Create a goal first.");
            Pause();
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int index = ReadInt("Enter goal number: ") - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;

            Console.WriteLine($"You earned {earned} points!");

            CheckLevelUp();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }

        Pause();
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
        Pause();
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int completed = int.Parse(parts[6]);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, completed));
            }
        }

        // Recompute level from score after load
        _level = (_score / 100) + 1;

        Console.WriteLine("Goals loaded.");
        Pause();
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 100) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Level up! You are now Level {_level}.");
        }
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a whole number.");
        }
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.Write("Press ENTER to continue...");
        Console.ReadLine();
    }
}
