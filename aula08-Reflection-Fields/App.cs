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
        FieldInfo[] fields = klass.GetFields(
            BindingFlags.Public | 
            BindingFlags.NonPublic | 
            BindingFlags.Instance);
        for(int i = 0; i < fields.Length; i++) {
            object val = fields[i].GetValue(obj); // recebe como parâmetro um target
            // if(fields[i].GetType().IsPrimitive ) // !!!! ERRO: representante de FieldInfo
            Type fieldType = fields[i].FieldType;
            Console.Write(fields[i].Name + " = ");
            if(fieldType.IsPrimitive || fieldType == typeof(String)) {
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
        LinkedList<String> l = new LinkedList<String>();
        l.Add("Isel");
        l.Add("Ola");
        l.Add("Super");
        // Logger.Log(l);
        
        School isel = new School("Lisbon", "ISEL");
        Student st1 = new Student(76145, "Ze Manel", isel);
        Student st2 = new Student(89755, "Maria Carica", isel);
        
        Logger.Log(isel);
        Logger.Log(st1);
        Logger.Log(st2);
        
        Course c = new Course("LEIC", new Student[]{st1, st2});
        Logger.Log(c);
    }
}

public class Student
{
    public readonly int nr;
    public readonly string name;
    public readonly School sch;
    public Student(int nr, string name, School sch) {
        this.nr = nr;
        this.name = name; 
        this.sch = sch;
    }   
}
public class School
{
    public readonly string location;
    public readonly string name;
    public School(string location, string name) {
        this.location = location;
        this.name = name;
    }
}

public class Course
{
    public readonly Student[] stds;
    public readonly string id;
    public Course(string id, Student[] stds) {
        this.stds = stds; 
        this.id = id;
    }
}