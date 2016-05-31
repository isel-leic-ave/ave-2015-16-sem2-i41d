using System;
using System.Collections.Generic;

public class Counter {
    private readonly int max;
    private readonly List<Action<int>> subs;
    
    public Counter(int max) 
    {
        this.max = max;
        this.subs = new List<Action<int>>();
    }
    public void AddSubscriber(Action<int> s) 
    {
        subs.Add(s);
    }
    private void Notify(int nr) 
    {
        foreach(Action<int> s in subs) 
        {
            s(nr); // <=> s.Invoke(nr)
        }
    }
    
    public void Start() {
        for(int i = 0; i < max; i++)
        {
            Notify(i);
        }
    }
}