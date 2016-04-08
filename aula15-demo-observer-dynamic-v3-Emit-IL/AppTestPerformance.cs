using System;
using System.Windows.Forms;
using System.Diagnostics;

class App {
    static void Main() {
        Counter pub = new Counter(1000);
        pub.AddSubscriberDynamicByEmit(new MySubscribers());
        double duration = measureCounterPerformance(pub);
        Console.WriteLine("Duration by Emit = " +  duration + "ms");
        
        pub = new Counter(1000);
        pub.AddSubscriberDynamic(new MySubscribers());
        duration = measureCounterPerformance(pub);
        Console.WriteLine("Duration by Reflection = " +  duration + "ms");
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
    
    public static void Dummy(int nr, long a) 
    {
    }

    public int ConsoleAlert(int nr) 
    {
        // Console.WriteLine("Count = {0}", nr);
        return nr;
    }

    public static void  MboxAlert(int nr) 
    {
        // string msg = String.Format("Count = {0}", nr);
        // MessageBox.Show(msg);
    }
}

