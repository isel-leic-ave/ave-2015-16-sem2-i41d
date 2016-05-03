using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
    
    static IEnumerable<R> Convert<T, R>(IEnumerable<T> src, Mapping<T, R> transf) {
        List<R> res = new List<R>();
        foreach(T item in src) res.Add(transf(item));
        return res;
    }  
 
    static IEnumerable<T> Distinct<T>(IEnumerable<T> src) {
        List<T> res = new List<T>();
        foreach(T item in src) if(!res.Contains(item)) res.Add(item);
        return res;
    }
  
     static IEnumerable<T> Take<T>(IEnumerable<T> src, int size) {
        List<T> res = new List<T>();
        int count = 0;
        foreach(T item in src) {
            if(count++ >= size) break;
            res.Add(item);
        }
        return res;
    }

    static void Print(string label) {
        Console.WriteLine(label);
    }
    static void Main()
    {
        List<String> lines = WithLines("i41d.txt");
        /*
        IEnumerable<Student> stds = Convert<String, Student>(lines, line => Student.Parse(line));
        IEnumerable<String> names = Convert<Student, String>(stds, s => s.name);
        names = Convert<String, String>(names, name => name.Split(' ')[0]);
        names = Distinct<String>(names);
        names = Take<String>(names, 4);
        */
        
        IEnumerable<Student> stds = Convert(lines, line => Student.Parse(line)); 
        IEnumerable<String> names = Convert(stds, s => s.name); // Inferir T = Student e R = String
        names = Convert(names, name => name.Split(' ')[0]);
        names = Distinct(names);
        names = Take(names, 4); // Inferir T = String
        
        foreach(object l in names)
            Console.WriteLine(l);
        
    }
}
