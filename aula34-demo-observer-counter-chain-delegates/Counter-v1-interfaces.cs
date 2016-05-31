using System;
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