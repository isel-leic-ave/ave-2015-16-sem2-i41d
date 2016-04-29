using System;
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
    
    static List<Student> ConvertToStudents(List<String> lines) {
        List<Student> res = new List<Student>();
        foreach(String l in lines) {
            res.Add(Student.Parse(l));
        }
        return res;
    }
    
    static List<String> ConvertToName(List<Student> stds) {
        List<String> res = new List<String>();
        foreach(Student s in stds) {
            res.Add(s.name);
        }
        return res;
    }
    
    static List<String> GetFirstName(List<String> names) {
        List<String> res = new List<String>();
        foreach(String name in names) {
            res.Add(name.Split(' ')[0]);
        }
        return res;
    }
 
    static List<String> Distinct(List<String> names) {
        List<String> res = new List<String>();
        foreach(String name in names) {
            if(!res.Contains(name))
                res.Add(name);
        }
        return res;
    }
  
    static void Main()
    {
        List<String> lines = WithLines("i41d.txt");
        List<String> names = Distinct(GetFirstName(ConvertToName(ConvertToStudents(lines))));
        names.Sort();
        foreach(String l in names)
            Console.WriteLine(l);
        
    }
}