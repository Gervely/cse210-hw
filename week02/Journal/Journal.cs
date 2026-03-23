using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }
    }

    public void SaveToCsv(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date,Prompt,Response,Emotion"); // en-tête CSV
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToCsvString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);
            _entries.Add(entry);
        }
    }
}
