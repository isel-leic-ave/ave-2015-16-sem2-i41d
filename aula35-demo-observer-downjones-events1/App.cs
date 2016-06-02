using System;
using System.Windows.Forms;

class SubscriberWrapper : Subscriber
{
    private DowjonesSimpler djSimpler;

    public SubscriberWrapper(DowjonesSimpler djSimpler)
    {
        this.djSimpler = djSimpler;
    }

    public void Occurrence(string title, string uri, DateTime when)
    {
        this.djSimpler.CallNewsEvent(title, uri, when);
    }
}

class DowjonesSimpler 
{
    private readonly DowjonesNews src;
    public event Action<string, string, string> NewsEvent;
    
    public DowjonesSimpler(DowjonesNews src) 
    { 
        this.src = src; 
        src.AddSubscriber(new SubscriberWrapper(this));
    }
    public void CallNewsEvent(string title, string uri, DateTime when)
    {
        if (NewsEvent != null)
            NewsEvent(title, uri, when.ToString());
    } 
    
    public void Pull() { 
        src.Pull(); 
    }
    
}

class App {
    static void Main() {
        DowjonesSimpler pub = new DowjonesSimpler(new DowjonesNews()); 
        pub.NewsEvent += (title, uri, when) => Console.WriteLine("{0} ---> {1}", when, title);
        Action<string,string, string> h1 = (title, uri, when) => MessageBox.Show(title);
        pub.NewsEvent += h1;
        pub.Pull();
        pub.NewsEvent -= h1;
        pub.Pull();
    }
}

