using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4);

            Console.WriteLine();
            Console.Write("Now breathe out... ");
            ShowCountDown(6);

            elapsed += 10;
        }

        DisplayEndingMessage();
    }
}
