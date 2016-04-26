using System;
using System.Reflection;


/*
 * Não é strongly typed => Não verifica em tempo de compilação se a operação op
 * é compatível, i.e. recebe 2 inteiros e retorna outro inteiro.
 * MethodInfo pode ser qualquer tipo de método.
 */
class Ui1 {
    /**
     * op reresenta uma operação Binária que recebe 2 inteiros e retorna 
     * um resultado de tipo inteiro.
     * O método representado por op é estático.
     */
    public static void Execute(MethodInfo op) {
        Console.WriteLine("Introduza o valor do operando 1: ");
        String line = Console.ReadLine();
        int n1 = int.Parse(line);
        Console.WriteLine("Introduza o valor do operando 2: ");
        line = Console.ReadLine();
        int n2 = int.Parse(line);
        object res = op.Invoke(null, new object[]{n1, n2});
        Console.WriteLine("op({0}, {1}) = {2}", n1, n2, res.ToString());
    }
}

interface IBinaryOperation { int Call(int n1, int n2); }

class Ui2 {
    /**
     * op reresenta uma operação Binária que recebe 2 inteiros e retorna 
     * um resultado de tipo inteiro.
     */
    public static void Execute(IBinaryOperation op) {
        Console.WriteLine("Introduza o valor do operando 1: ");
        String line = Console.ReadLine();
        int n1 = int.Parse(line);
        Console.WriteLine("Introduza o valor do operando 2: ");
        line = Console.ReadLine();
        int n2 = int.Parse(line);
        int res = op.Call(n1, n2);
        Console.WriteLine("op({0}, {1}) = {2}", n1, n2, res);
    }
}

delegate int BinaryOperation (int n1, int n2);

class Ui3 {
    /**
     * op reresenta uma operação Binária que recebe 2 inteiros e retorna 
     * um resultado de tipo inteiro.
     */
    public static void Execute(BinaryOperation op) {
        Console.WriteLine("Introduza o valor do operando 1: ");
        String line = Console.ReadLine();
        int n1 = int.Parse(line);
        Console.WriteLine("Introduza o valor do operando 2: ");
        line = Console.ReadLine();
        int n2 = int.Parse(line);
        int res = op(n1, n2); // op.Invoke(n1, n2);
        Console.WriteLine("op({0}, {1}) = {2}", n1, n2, res);
    }
}

class App {
    public static int Add(int n1, int n2) { return n1 + n2; }
    public static int Sub(int n1, int n2) { return n1 - n2; }
    public static int Power(int n) { return n * n; }
    public int Mul(int n1, int n2) { return n1 * n2; }
    
    static void Main() {
        // Ui1.Execute(typeof(App).GetMethod("Add"));
        // Ui1.Execute(typeof(App).GetMethod("Sub"));
        // Ui1.Execute(typeof(App).GetMethod("Power")); => Excepção
        
        // Ui2.Execute(new Add());
        // Ui2.Execute(new Sub());
        
        // Ui3.Execute((BinaryOperation) Delegate.CreateDelegate(typeof(BinaryOperation), typeof(App), "Add"));
        // Ui3.Execute(new BinaryOperation(App.Add));
        // Ui3.Execute(App.Sub);
        // Ui3.Execute(new App().Mul);
        Ui3.Execute((a, b) => a/b);
        Ui3.Execute((a, b) => { return a/b; });
        Ui3.Execute((int a, int b) => { return a/b; });
        
        // Ui3.Execute(App.Power); // Erro de Compilação
    }
}

class Add : IBinaryOperation {
    public int Call(int n1, int n2) { return n1 + n2; }
}

class Sub : IBinaryOperation {
    public int Call(int n1, int n2) { return n1 - n2; }
}
/*
class Power : IBinaryOperation {
    public int Call(int n)  // Erro de Compilação prq não obedece a IBinaryOperation
    { 
        return n * n; 
    }
}
*/