using System;
using System.IO;

public static class Logger
{
    private static readonly string _filePath = "activity_log.txt";

    public static void Log(string activityName, int durationSeconds, string extra = "")
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string line = $"{timestamp} | {activityName} | {durationSeconds} seconds";

        if (!string.IsNullOrWhiteSpace(extra))
        {
            line += $" | {extra}";
        }

        File.AppendAllText(_filePath, line + Environment.NewLine);
    }
}

