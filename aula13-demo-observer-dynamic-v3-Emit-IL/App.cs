using System;
using System.Windows.Forms;


class App {
    static void Main() {
        Counter pub = new Counter(3);
        
        /*
         * Adiciona dinamicamente todos os métodos compatíveis com 
         * a descritor de Update da interface Subscriber.
         */
        // pub.AddSubscriberDynamic(new MySubscribers());
        pub.AddSubscriberDynamicByEmit(new MySubscribers());
        
        pub.Start();
    }
}

public class MySubscribers {
    
    public static void Dummy(int nr, long a) 
    {
    }

    public int ConsoleAlert(int nr) 
    {
        Console.WriteLine("Count = {0}", nr);
        return nr++;
    }

    public static void  MboxAlert(int nr) 
    {
        string msg = String.Format("Count = {0}", nr);
        MessageBox.Show(msg);
    }
}

