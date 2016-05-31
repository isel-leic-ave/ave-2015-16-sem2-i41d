using System;
using System.Windows.Forms;


class App {
    static void Main() {
        Counter pub = new Counter(3);
        pub.CountEvent += nr => Console.WriteLine("Count = {0}", nr); // call add_CountEvent
        Action<int> a  = nr => MessageBox.Show(String.Format("Count = {0}", nr));
        pub.CountEvent += a;
        pub.Start();
        pub.CountEvent -= a;
        pub.Start();
    }
}
