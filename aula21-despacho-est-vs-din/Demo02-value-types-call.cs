using System;

class A {    
    public void Print() { 
        Console.WriteLine("A");
    }
}

struct S {
    public void Print() { 
        Console.WriteLine("S");
    }
}

class App {
    static void Main() {
        A a = new A();
        a.Print(); // call ou callvirt? => ldloc + callvirt
        
        S s = new S(); // IL ??? => initobj
        s.Print(); // call ou callvirt ??? => ldloca + call um TV nunca é null
        
        Type klass = s.GetType(); // il ??? box  + call => Pq método herdado e NAO redifinido
        
        int n = s.GetHashCode(); // constrained + callvirt <=> box + call (constrained fora do ambito da materia)        
        
        Console.WriteLine(klass);
        
        klass = a.GetType(); // callvirt ao GetType();
        Console.WriteLine(klass);
    }
}

