using System;
using System.Windows.Forms;


class App {
    static void Main() {
        Counter pub = new Counter(3);
        pub.AddSubscriber(new ConsoleViewer());
        // pub.AddSubscriber(new MboxViewer());
        pub.Start();
    }
}

class ConsoleViewer : Subscriber {
    public void Update(int nr) {
        Console.WriteLine("Count = {0}", nr);
    }
}

class MboxViewer : Subscriber {
    public void Update(int nr) {
        string msg = String.Format("Count = {0}", nr);
        MessageBox.Show(msg);
    }
}

