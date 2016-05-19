public delegate TRes PipeFunc<in T, out TRes>(T arg);

// out covariant
// in contravarian

public class App
{
    public static void Main() {
        PipeFunc<C, A> f1  = App.F1;
        PipeFunc<B, B> f2  = App.F2; 
        PipeFunc<B, B> f3  = App.F3; 
        
    }

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
