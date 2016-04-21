using System;

interface Printer {void Print();}
interface Setter { void SetX(int val); void SetY(int val);}

struct Point : Printer, Setter {
    public int x, y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public void Print() {
        Console.WriteLine("[{0}, {1}]", x, y);
    }
    public void SetX(int val) {
        this.x = val;
    }
    public void SetY(int val) {
        this.y = val;
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
        
        p = (Point) pr; // unbox
        
        // pr.x = 9; // Erro de Compilação
        
        // ((Point) pr).y = 9;  // => unbox + ldloca + stfld => Erro: Cannot modify the result of an unboxing conversion
        
        p = (Point) pr; // unbox
        p.y = 9; //ldloca + ldc.i4 9 + stfld 
        pr.Print(); // [5, 7]
        
        ((Setter) pr).SetY(9); // => castclass + callvirt SetY
        pr.Print(); // [5, 9] 
    }

}

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
