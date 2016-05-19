using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Demo
{
    public static B F1(B b)
    {
        return b;
    }
    public static C F2(A a)
    {
        return new C("ola");
    }
    public static B F3(B b)
    {
        return new B(b.msg + " super");
    }

}

public class A { }
public class B : A
{
    readonly public string msg;
    public B(string msg) { this.msg = msg; }
}
public class C : B {
    public C(string p) : base(p) { }
}
