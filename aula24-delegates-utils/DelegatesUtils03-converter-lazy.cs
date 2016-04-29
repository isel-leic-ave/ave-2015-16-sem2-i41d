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
    
    static IEnumerable Convert(IEnumerable src, Mapping transf) {
        return new EnumerableConverter(src, transf);
    }  
 
    static IEnumerable Distinct(IEnumerable src) {
        return new EnumerableDistinct(src);
    }
  
     static IEnumerable Take(IEnumerable src, int size) {
        return new EnumerableMax(src, size);
    }

    static void Print(string label) {
        Console.WriteLine(label);
    }
    static void Main()
    {
        IList lines = WithLines("i41d.txt");
        IEnumerable stds = Convert(lines, line => {Print("-> Student"); return Student.Parse((String)line);});
        IEnumerable names = Convert(stds, s => {Print("-> name"); return ((Student) s).name;});
        names = Convert(names, name => {Print("-> first name"); return ((String) name).Split(' ')[0];});
        names = Distinct(names);
        names = Take(names, 10);
         foreach(object l in names)
            Console.WriteLine(l);
        
    }
}

delegate object Mapping(object item);

class EnumerableConverter : IEnumerable{
    readonly IEnumerable src;
    readonly Mapping transf;
    public EnumerableConverter(IEnumerable src, Mapping transf) {
        this.src = src; this.transf = transf;
    }
    public IEnumerator GetEnumerator() {
        return new EnumeratorConverter(src, transf);
    }
}

class EnumeratorConverter : IEnumerator{
    readonly IEnumerator src;
    readonly Mapping transf;
    public EnumeratorConverter(IEnumerable src, Mapping transf) {
        this.src = src.GetEnumerator(); this.transf = transf;
    }
    
    public bool MoveNext() {
        return src.MoveNext();
    }
    
    public object Current {
        get{ return transf(src.Current); }
    }
    
    public void Reset() { 
        src.Reset();
    }
}

class EnumerableDistinct : IEnumerable{
    readonly IEnumerable src;
    public EnumerableDistinct(IEnumerable src) {
        this.src = src; 
    }
    public IEnumerator GetEnumerator() {
        return new EnumeratorDistinct(src);
    }
}

class EnumeratorDistinct : IEnumerator{
    readonly IEnumerator src;
    readonly IList selected;
    public EnumeratorDistinct(IEnumerable src) {
        this.src = src.GetEnumerator();
        this.selected = new ArrayList();
    }
    
    public bool MoveNext() {
        while( src.MoveNext() ){
            if(!selected.Contains(src.Current)) {
                selected.Add(src.Current);
                return true;
            }    
        }
        return false;
    }
    
    public object Current {
        get{ return src.Current; }
    }
    
    public void Reset() { 
        src.Reset();
    }
}

class EnumerableMax : IEnumerable{
    readonly IEnumerable src;
    readonly int max;
    
    public EnumerableMax(IEnumerable src, int max) {
        this.src = src; 
        this.max = max;
    }
    public IEnumerator GetEnumerator() {
        return new EnumeratorMax(src, max);
    }
}

class EnumeratorMax : IEnumerator{
    readonly IEnumerator src;
    readonly int max;
    public EnumeratorMax(IEnumerable src, int max) {
        this.src = src.GetEnumerator();
        this.max = max;
    }
    
    public bool MoveNext() {
        return true;
    }
    
    public object Current {
        get{ return src.Current; }
    }
    
    public void Reset() { 
        src.Reset();
    }
}
