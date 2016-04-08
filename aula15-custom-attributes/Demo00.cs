using System;

class MyTagAttribute : Attribute {}

[MyTag]
public class A
{
    [MyTag] void Foo() {}
}

public class App 
{
    static void Main() {}
}
