using System;
class Boss {
    public virtual void Foo() {Console.WriteLine("Boss::Foo");}
    public void Bar() {Console.WriteLine("Boss::Bar");}
}
class Manager : Boss {
    public override  void Foo() {Console.WriteLine("Manager::Foo");}
    public virtual void Bar() {Console.WriteLine("Manager::Bar");}
}
class Employee : Manager{
    public void Foo() {Console.WriteLine("Employee::Foo");}
    public override  void Bar() {Console.WriteLine("Employee::Bar");}
}
class App {
    static void Main() {
        Employee e = new Employee();
        Boss b = e;
        Manager m = e;
        
        b.Foo(); // Manager
        b.Bar(); // Boss
        m.Foo(); // Manager
        m.Bar(); // Employee
        e.Foo(); // Employee
        e.Bar(); // Employee
    }
}
