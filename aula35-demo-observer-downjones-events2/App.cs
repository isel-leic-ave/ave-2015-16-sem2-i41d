using System;
using System.Windows.Forms;

class SubscriberWrapper : Subscriber
{
    private Action<string, string, string> handler;

    public SubscriberWrapper(Action<string, string, string> handler)
    {
        this.handler = handler;
    }

    public void Occurrence(string title, string uri, DateTime when)
    {
        handler(title, uri, when.ToString());
    }
    public override bool Equals(object other) {
        SubscriberWrapper o = other as SubscriberWrapper;
        if(o == null) return false;
        return this.handler.Equals(o.handler);
    }
    public override int GetHashCode() {
        return this.handler.GetHashCode();
    }
}

class DowjonesSimpler 
{
    private readonly DowjonesNews src;
    public event Action<string, string, string> NewsEvent 
    {
        add { src.AddSubscriber(new SubscriberWrapper(value)); }
        remove { src.RemoveSubscriber(new SubscriberWrapper(value)); }
    }
    
    public DowjonesSimpler(DowjonesNews src) 
    { 
        this.src = src; 
    }    
    public void Pull() { 
        src.Pull(); 
    }
    
}

class App {
    static void msgBox(string title, string uri, string when) {
        MessageBox.Show(title);
    }
    static void Main() {
        DowjonesSimpler pub = new DowjonesSimpler(new DowjonesNews()); 
        pub.NewsEvent += (title, uri, when) => Console.WriteLine("{0} ---> {1}", when, title);
        pub.NewsEvent += App.msgBox;
        pub.Pull();
        pub.NewsEvent -= App.msgBox; // <=> new Action<string, string, string>(App.msgBox);
        pub.Pull();
       
    }
}

