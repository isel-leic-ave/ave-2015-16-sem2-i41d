using System;
using System.Collections.Generic;

public class Counter {
    private readonly int max;
    private Action<int> subs;
    
    public Counter(int max) 
    {
        this.max = max;
    }
    public void AddSubscriber(Action<int> s) 
    {
        subs += s; // <=> (Action<int>) Delegate.Combine(sub, s);
    }
    public void RemoveSubscriber(Action<int> s) 
    {
        subs -= s; // <=> (Action<int>) Delegate.Remove(sub, s);
    }
    private void Notify(int nr) 
    {
        subs(nr); // <=> subs.Invoke(nr) <=> chama todos os delegates da _invocationList
        /* <=>
        foreach(Action<int> s in subs.GetInvocationList()) 
        {
            s(nr);
        }*/
    }
    
    public void Start() {
        for(int i = 0; i < max; i++)
        {
            Notify(i);
        }
    }
}