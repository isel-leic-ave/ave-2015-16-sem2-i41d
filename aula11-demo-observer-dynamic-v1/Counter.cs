using System;
using System.Reflection;
using System.Collections.Generic;

public interface Subscriber{
    void Update(int nr);
}

public class Counter {
    private readonly int max;
    private readonly List<Subscriber> subs;
    private readonly List<MethodInfo> handlers;
    
    public Counter(int max) 
    {
        this.max = max;
        this.subs = new List<Subscriber>();
        this.handlers = new List<MethodInfo>();
    }
    public void AddSubscriber(Subscriber s) 
    {
        subs.Add(s);
    }
    public void AddSubscriberDynamic(object target) 
    {
        MethodInfo [] ms = target.GetType().GetMethods();
        foreach(MethodInfo m in ms) {
            ParameterInfo[] ps = m.GetParameters();
            if( ps.Length == 1 && ps[0].ParameterType == typeof(int) )
            {
                handlers.Add(m);
            }
        }
    }
    private void Notify(int nr) 
    {
        foreach(Subscriber s in subs) 
        {
            s.Update(nr);
        }
        foreach(MethodInfo h in handlers) 
        {
            // !!!!!!! NÃO suporta métodos de instância.
            if(h.IsStatic)
                h.Invoke(null, new object[1]{nr});
        }
    }
    
    public void Start() {
        for(int i = 0; i < max; i++)
        {
            Notify(i);
        }
    }
}