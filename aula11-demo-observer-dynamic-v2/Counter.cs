using System;
using System.Reflection;
using System.Collections.Generic;

public interface Subscriber{
    void Update(int nr);
}

public class Counter {
    private readonly int max;
    private readonly List<Subscriber> subs;
    
    public Counter(int max) 
    {
        this.max = max;
        this.subs = new List<Subscriber>();
    }
    public void AddSubscriber(Subscriber s) 
    {
        subs.Add(s);
    }
    public void AddSubscriberDynamic(object target) 
    {
        if(target == null) return;
        MethodInfo [] ms = target.GetType().GetMethods();
        foreach(MethodInfo m in ms) {
            ParameterInfo[] ps = m.GetParameters();
            if( ps.Length == 1 && ps[0].ParameterType == typeof(int) )
            {
                // subs.Add(m); // Gostava de poder fazer MAS MethodInfo não é Subscriber
                subs.Add(new SubscriberWrapper(target, m));
            }
        }
    }
    class SubscriberWrapper : Subscriber {
        private readonly object target;
        private readonly MethodInfo handler;
        public SubscriberWrapper(object t, MethodInfo h) {target = t; handler = h;}
        public void Update(int nr) {
            handler.Invoke(target, new object[1]{nr});
        }
    }
    
    private void Notify(int nr) 
    {
        foreach(Subscriber s in subs) 
        {
            s.Update(nr);
        }
    }
    
    public void Start() {
        for(int i = 0; i < max; i++)
        {
            Notify(i);
        }
    }
}