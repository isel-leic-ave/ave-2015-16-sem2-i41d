import java.util.*;

class Account
{
    public final double ammount;
    public final String id;

    public Account(double ammount, String id)
    {
        this.ammount = ammount;
        this.id = id;
    }

    public String toString()
    {
        return String.format("%f %s", ammount, id);
    }
}

class Student {}

class App
{
    public static void main(String [] args)
    {
        List<Account> accs = new ArrayList<Account>(); // ++ Expressividade
        List<Student> stds = new ArrayList<Student>(); // outro tipo fechado: List<Student>
        accs.add(new Account(37.1, "iAGF"));
        accs.add(new Account(87.9, "LKJG"));
        // accs.Add("Account 87.9 LKJG"); // ++ Robustez
        
        Account ac1 = accs.get(0); // !!! desempenho HÁ checkcast <=> IL castclass
    }
}
