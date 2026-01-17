using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void Search(string keyword)
    {
        bool foundAny = false;

        foreach (Entry entry in _entries)
        {
            if (entry._date.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._promptText.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry._entryText.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                foundAny = true;
            }
        }

        if (!foundAny)
        {
            Console.WriteLine("No matching entries found.");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }

        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string fileName)
    {
        _entries.Clear();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            if (parts.Length < 3)
            {
                continue;
            }

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];

            // If the entry text itself contains '|', re-join it safely:
            entry._entryText = string.Join("|", parts, 2, parts.Length - 2);

            _entries.Add(entry);
        }

        Console.WriteLine("Journal loaded.");
    }
}
