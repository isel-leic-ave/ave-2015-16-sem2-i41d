using System;
using System.Windows.Forms;


class App {
    static void Main() {
        DowjonesNews pub = new DowjonesNews();
        pub.AddSubscriber(new ConsoleViewer());
        pub.AddSubscriber(new MboxViewer());
        pub.Pull();
       
    }
}

class ConsoleViewer : Subscriber {
    public void Occurrence(string title, string uri, DateTime when) {
        Console.WriteLine("{0} ---> {1}", when, title);
    }
}

class MboxViewer : Subscriber {
    public void Occurrence(string title, string uri, DateTime when) {
        string msg = String.Format("{0} ---> {1}", when, title);
        MessageBox.Show(msg);
    }
}

