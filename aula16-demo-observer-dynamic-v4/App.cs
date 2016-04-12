using System;
using System.Windows.Forms;
using System.Diagnostics;

class App {
    static void Main() {
    
        Counter c = new Counter(3);
        c.AddSubscriberDynamic(new MySubscribers());
        c.Start();
    }

    static double measureCounterPerformance(Counter c){
        double duration = double.MaxValue;
        for(int i = 0; i < 15; i++) {
            Stopwatch time = new Stopwatch();
            time.Start();
            c.Start(); // Medir o tempo de execução
            double test = time.Elapsed.TotalMilliseconds;
            duration = test < duration ? test : duration;
        }
        return duration;
    }    
}

public class MySubscribers {
    
    public static void Dummy(int nr) 
    {
        Console.WriteLine("Este metodo nao devia ser chamado");
    }

    [SubscriberHandler(1)]
    public int ConsoleAlert(int nr) 
    {
        Console.WriteLine("Count = {0}", nr);
        return nr;
    }

    [SubscriberHandler(0)]
    public static void  MboxAlert(int nr) 
    {
        string msg = String.Format("Count = {0}", nr);
        MessageBox.Show(msg);
    }
}

