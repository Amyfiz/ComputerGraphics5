using System.Collections.Generic;
using System;

public class LSystem
{
    public string Axiom { get; private set; }
    public float Angle { get; private set; }
    public float InitialDirection { get; private set; }
    public Dictionary<char, string> Rules { get; private set; }

    public LSystem(string filePath)
    {
        Rules = new Dictionary<char, string>();
        LoadFromFile(filePath);
    }

    private void LoadFromFile(string filePath)
    {
        var lines = System.IO.File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            if (parts.Length >= 3 && !line.Contains("->"))
            {
                Axiom = parts[0].Trim();
                if (!float.TryParse(parts[1], out float angle))
                {
                    throw new FormatException($"Неправильный формат угла: {parts[1]}");
                }
                Angle = angle;

                if (!float.TryParse(parts[2], out float initialDirection))
                {
                    throw new FormatException($"Неправильный формат начального направления: {parts[2]}");
                }
                InitialDirection = initialDirection;
            }
            else if (parts.Length == 2)
            {
                Rules[parts[0].Trim()[0]] = parts[1].Trim();
            }
            else
            {
                throw new FormatException($"Неправильный формат строки: {line}");
            }
        }
    }
}
