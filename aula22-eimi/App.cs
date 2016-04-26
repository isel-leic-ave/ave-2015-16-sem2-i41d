using System;

interface I { void M();}

interface Y { void M();}

class A : I { public void M() { Console.WriteLine("A"); }}

class B : I, Y { 
    // M() é privado
    void I.M() { Console.WriteLine("B via I"); }
    
    void Y.M() { Console.WriteLine("B via Y"); }
    
    public void Aux() { 
        // this.M(); // M() não é acessível
        ((I) this).M();
    }
}


class App {
    static void Main() {
        B b = new B();
        // b.M(); // M() é privado e não é acessível numa referencia do tipo B
        b.Aux();
        
        I i = b; // casting implícito
        i.M();
        
        Y y = b; // casting implícito
        y.M();
    }
}
