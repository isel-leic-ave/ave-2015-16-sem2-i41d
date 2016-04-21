interface Printer {void Print();}


class Logger {
    public void Log1(object o) {
        // Short path
        if(o is Printer) { // isinst
            Printer p = (Printer) o; // castclass
            p.Print();
        }
    
        // Prints the object state through Reflection
    }
    
    public void Log2(object o) {
        // Short path
        Printer p = o as Printer; // isinst
        if(p != null) {
            p.Print();
        }
    
        // Prints the object state through Reflection
    }
}

class App {
    static void Main() {
        
    }

}