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
    
    delegate object Mapping(object item);
    
    static IList Convert(IList src, Mapping transf) {
        IList res = new ArrayList();
        foreach(object item in src) {
            res.Add(transf(item));
        }
        return res;
    }  
 
    static IList Distinct(IList src) {
        IList res = new ArrayList();
        foreach(object item in src) {
            if(!res.Contains(item))
                res.Add(item);
        }
        return res;
    }
  
     static IList Take(IList src, int size) {
        IList res = new ArrayList();
        foreach(object item in src) {
            if(size-- > 0)
                res.Add(item);
            else
                break;
        }
        return res;
    }
    
    static void Print(string label) {Console.WriteLine(label);}
    static void Main()
    {
        IList lines = WithLines("i41d.txt");
        IList stds = Convert(lines, line => {Print("-> Student"); return Student.Parse((String)line);});
        IList names = Convert(stds, s => {Print("-> name"); return ((Student) s).name;});
        names = Convert(names, name => {Print("-> first name"); return ((String) name).Split(' ')[0];});
        // names = Distinct(names);
        // names = Take(names, 10);
        // foreach(object l in names)
            // Console.WriteLine(l);
        
    }
}