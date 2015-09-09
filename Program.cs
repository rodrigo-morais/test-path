using System;
using System.Collections.Generic;

public class Path
{
    private List<string> parts = new List<string>();

    public string CurrentPath { get; private set; }

    private void addPartToPath(string part)
    {
        this.parts.Add(part);
    }

    private void removeLastPartFromPath()
    {
        this.parts.RemoveAt(this.parts.Count - 1);
    }

    public Path(string path)
    {
        path = path.Replace("\"", "/");
        path = path.Replace("\\", "/");
        foreach (var part in path.Split('/'))
        {
            this.addPartToPath(part);
        }
        this.CurrentPath = path;
    }

    public Path Cd(string newPath)
    {
        newPath = newPath.Replace("\"", "/");
        newPath = newPath.Replace("\\", "/");

        foreach (var part in newPath.Split('/'))
        {
            if (part.Equals(".."))
            {
                this.removeLastPartFromPath();
            }
            else
            {
                this.addPartToPath(part);
            }
        }

        this.CurrentPath = String.Join("/", this.parts.ToArray());

        return this;
    }

    public static void Main(string[] args)
    {
        Path path = new Path("/a/b/c/d");
        Console.WriteLine(path.Cd("../x").CurrentPath);
    }
}