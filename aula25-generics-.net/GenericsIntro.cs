using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Account
{
    public readonly double ammount;
    public readonly string id;

    public Account(double ammount, String id)
    {
        this.ammount = ammount;
        this.id = id;
    }

    public override String ToString()
    {
        return String.Format("{0} {1}", ammount, id);
    }
    public void Print()
    {
        Console.WriteLine(this.ToString());
    }
}

class Student {}
static class App
{
    static void Main()
    {
        List<Account> accs = new List<Account>(); // ++ Expressividade
        List<Student> stds = new List<Student>(); // outro tipo fechado: List<Student>
        accs.Add(new Account(37.1, "iAGF"));
        accs.Add(new Account(87.9, "LKJG"));
        // accs.Add("Account 87.9 LKJG"); // ++ Robustez
        
        Account ac1 = accs[0]; // ++  desempenho Não há castclass
    }
}
