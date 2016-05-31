using System;
using System.Windows.Forms;


class DowjonesSimpler {
    private readonly DowjonesNews src;
    public event Action<string, string, string> NewsEvent;
    
    public DowjonesSimpler(DowjonesNews src) { 
        this.src = src; 
    }
    public void Pull() { 
        src.Pull(); 
    }
    
}

class App {
    static void Main() {
    /*
        DowjonesNews pub = new DowjonesNews();
        pub.AddSubscriber(new ConsoleViewer());
        // pub.AddSubscriber(new MboxViewer());
        pub.Pull();
    */  
        DowjonesSimpler pub = new DowjonesSimpler(new DowjonesNews()); 
        pub.NewsEvent += (title, uri, when) => Console.WriteLine("{0} ---> {1}", when, title);
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

