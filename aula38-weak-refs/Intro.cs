using System;

class A { 
    public readonly B b = new B();
    ~A(){Console.WriteLine("Finalizing A...."); }
}
class B { 
    ~B(){Console.WriteLine("Finalizing B...."); }
}

class App {

    static void PrintRunningGC(){
        Console.WriteLine("Running GC...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    static void Main() {
        WeakReference<A> a = new WeakReference<A>(new A());
        
        PrintRunningGC();
        
        Console.WriteLine("Wait for user to hit <Enter>");
		Console.ReadLine();
        
        A target;
        if(a.TryGetTarget(out target)){
            Console.WriteLine(target + " " + target.GetHashCode());
            Console.WriteLine(target.b + " " + target.b.GetHashCode());
        }

    }
}