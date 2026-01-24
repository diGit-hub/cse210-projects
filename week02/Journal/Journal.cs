using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

    public void SaveToFile(string file)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        string jsonString = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(file, jsonString);
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string jsonString = File.ReadAllText(file);
            var options = new JsonSerializerOptions { IncludeFields = true };
            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString, options);
        }
    }
}