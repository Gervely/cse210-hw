using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _emotion; // BONUS : champ supplémentaire

    public Entry(string date, string prompt, string response, string emotion = "")
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _emotion = emotion;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        if (!string.IsNullOrEmpty(_emotion))
        {
            Console.WriteLine($"Emotion: {_emotion}");
        }
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}|{_emotion}";
    }

    public string ToCsvString()
    {
        return $"\"{_date}\",\"{_prompt}\",\"{_response}\",\"{_emotion}\"";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("|");
        return new Entry(parts[0], parts[1], parts[2], parts.Length > 3 ? parts[3] : "");
    }
}
