using System;

class A{}
class B{}

class App {
    static void Main() {
        A a = new A();
        A c = new A();
        Type ta = a.GetType();
        Type tc = c.GetType();
        Console.WriteLine("ta == tc --> " +  (ta == tc)); // Cmp Identidade --> Cmp Referencias
        
        Type tb = new B().GetType();
        Console.WriteLine("ta == tb --> " +  (ta == tb)); // Cmp Identidade --> Cmp Referencias
        
        Type klassB = typeof(B);
        Console.WriteLine("klassB == tb --> " +  (klassB == tb)); // Cmp Identidade --> Cmp Referencias
        
        Type klassInt = 5.GetType(); // Todos os tipos extende de Object directa ou indirectamente
    }
}
