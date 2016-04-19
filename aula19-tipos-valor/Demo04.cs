using System;

interface Printer {void Print();}

class Logger {
    public static void Log(object o) {
        Printer p = o as Printer; // isinst
        if(p != null) {
            p.Print();
        }    
        // Prints the object state through Reflection
    }
    public static void Log(Printer p) {
        p.Print();
    }
}

struct Point : Printer{
    int x, y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    
    public void Print() {
        Console.WriteLine("[{0}, {1}]", x, y);
    }
}

class App {
    static void Main() {
        // Point p = new Point(); // ldloca + initobj;
        
        Point p = new Point(5, 7); // ldloca + call Point::ctor(int, int)
        Logger.Log(p); // call Logger::Log(Printer)
        
        p.Print(); // ldloca + call Point::Print
        Printer pr = (Printer) p; // box
        pr.Print(); // ldloc + callvirt Printer::Print
        
    }

}