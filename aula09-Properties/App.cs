using System;
using System.Reflection;

public class LinkedList<T> {
    private readonly Node<T> head = new Node<T>(default(T), null);
    
    public LinkedList() {
        head.next = head;
    }
    public void Add(T val){
        Node<T> n = new Node<T>(val, head.next);
        this.head.next = n;
    }    
    public bool Contains(T elem) {
        for(Node<T> h = head.next; h != head; h = h.next) {
            if(h.val.Equals(elem))
                return true;
        }
        return false;
    }
    class Node<R> {
        public R val;
        public Node<R> next;
        public Node(R val, Node<R> next) {
            this.val = val;
            this.next = next;
        }
    }
}

public class Logger {
    public static void Log(object obj) {
        if(obj == null) {
            Console.Write("null");
            return;
        }
        Type klass = obj.GetType();
        Console.Write(klass.Name + ": ");
        PropertyInfo[] props = klass.GetProperties(
            BindingFlags.Public | 
            BindingFlags.NonPublic | 
            BindingFlags.Instance);
        for(int i = 0; i < props.Length; i++) {
            // object val = props[i].GetValue(obj); // recebe como parâmetro um target
            object val = props[i].GetGetMethod().Invoke(obj, new object[0]);
            Type propType = props[i].PropertyType;
            Console.Write(props[i].Name + " = ");
            if(propType.IsPrimitive || propType == typeof(String)) {
                if(val == null) Console.Write("null");
                else Console.Write(val.ToString() + ", ");
            }
            else
                Logger.Log(val);
        }
        Console.WriteLine();
    }
}

class App {
    static void Main() {
        
        Student st1 = new Student(76145, "Ze Manel");
        Student st2 = new Student(89755, "Maria Carica");
         
        Logger.Log(st1);
        Logger.Log(st2);
        
        Point p = new Point(5, 7);
        Logger.Log(p);
       
    }
}

class Point {
    public Point(int x, int y) {
        this.X = x; // compilador => set_X(x);
        this.Y = y; // compilador => set_X(x);
    }
    public int X{ get; set; } // O compilador gera o backing field
    public int Y{ get; set; } // O compilador gera o backing field
    
    public double Module{ // SEM backing field e sem Set => Readonly
        get { return Math.Sqrt(X*X + Y*Y); } // get_X() * get_X()
    }
}

public class Student
{
    private int nr; // backing field da propriedade Nr
    private string name;
    
    public int Nr 
    {
        get{ return nr;}
        set{ this.nr = value; } // value parametro implicito do set
    }  
    public String Name
    {
        get{ return name;}
        set{ this.name = value; } // value parametro implicito do set
    }  
    public Student(int nr, string name) {
        this.nr = nr;
        this.name = name; 
    }   
}

public class Course
{
    private Student[] stds;
    
    public Course(string id, Student[] stds) {
        this.stds = stds; 
        this.Id = id;
    }
    
    public string Id{ get; set; }
    
    public Student this[int i] { 
        get{ return stds[i]; }
        set{ 
            if(i < 0 || i >= stds.Length)
                throw new ArgumentException("Index out of bounds: [0, " + (stds.Length - 1) + "]");
            stds[i] = value; 
        }
    }
}


