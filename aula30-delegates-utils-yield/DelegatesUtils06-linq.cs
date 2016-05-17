using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq; // Integrated Query Language

public class Student
{
    public readonly int nr;
    public readonly string name;
    public readonly int group;
    public readonly string githubId;

    public Student(int nr, String name, int group, string githubId)
    {
        this.nr = nr;
        this.name = name;
        this.group = group;
        this.githubId = githubId;
    }

    public override String ToString()
    {
        return String.Format("{0} {1} ({2}, {3})", nr, name, group, githubId);
    }
    public void Print()
    {
        Console.WriteLine(this.ToString());
    }
    
    public static Student Parse(string src){
        string [] words = src.Split('|');
        return new Student(
            int.Parse(words[0]),
            words[1],
            int.Parse(words[2]),
            words[3]);
    }
}

delegate R Mapping<T, R>(T item);

static class App
{
    
    static List<String> WithLines(string path)
    {
        string line;
        List<string> res = new List<string>();
        using (StreamReader file = new StreamReader(path, Encoding.UTF8)) // <=> try-with resources do Java >= 7
        {
            while ((line = file.ReadLine()) != null)
            {
                res.Add(line);
            }
        }
        return res;
    }
    
    static IEnumerable<R> Convert<T, R>(this IEnumerable<T> src, Mapping<T, R> transf) {
        foreach(T item in src) yield return transf(item);
    }  
 
    static IEnumerable<T> Distinct<T>(this IEnumerable<T> src) {
        List<T> res = new List<T>();
        foreach(T item in src) 
            if(!res.Contains(item)) 
            {
                res.Add(item);
                yield return item;
            }
    }
  
    static IEnumerable<T> Take<T>(this IEnumerable<T> src, int size) {
        int count = 0;
        foreach(T item in src) {
            if(count++ >= size) break;
            yield return item;
        }
    }

    static void ForEach<T>(this IEnumerable<T> src, Action<T> a) {
        foreach(T item in src) {
            a(item);
        }
    }
    
    static void Print(string label) {
        Console.WriteLine(label);
    }
    static void Main()
    {
        List<String> lines = WithLines("i41d.txt");
        
        ForEach(
            Take(
                Distinct(
                    Convert(
                        Convert(
                            Convert(
                                lines, 
                                line => Student.Parse(line)), 
                            s => s.name), 
                        name => name.Split(' ')[0])
                ), 
                4), 
            Console.WriteLine
        );
        Console.WriteLine("*************");
        lines
            .Convert(line => Student.Parse(line))
            .Convert(s => s.name)
            .Convert(name => name.Split(' ')[0])
            .Distinct()
            .Take(4)
            .ForEach(Console.WriteLine);
        
        Console.WriteLine("*************");
        lines
            .Select(line => Student.Parse(line))
            .Select(s => s.name)
            .Select(name => name.Split(' ')[0])
            .Where(name => name.StartsWith("P"))
            .Distinct()
            .Take(4)
            .ForEach(Console.WriteLine);
    }
}
