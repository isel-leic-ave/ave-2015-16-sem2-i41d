using System;
using System.Collections.Generic;

public class Counter {
    private readonly int max;
    public event Action<int> CountEvent;
    
    public Counter(int max) 
    {
        this.max = max;
    }

    private void Notify(int nr) 
    {
        CountEvent(nr); // <=> CountEvent.Invoke(nr) <=> chama todos os delegates da 
    }
    
    public void Start() {
        for(int i = 0; i < max; i++)
        {
            Notify(i);
        }
    }
}