using System;

class A {    
    public virtual void Print() { 
        Console.WriteLine("A");
    }
}

class B : A {    
    public override void Print() { 
        Console.WriteLine("B");
        base.Print(); // ???? call ou callvirt => call para evitar cilo infinito
    }
}

class App {
    static void Main() {
        A a = new B();
        a.Print();
    }
}

