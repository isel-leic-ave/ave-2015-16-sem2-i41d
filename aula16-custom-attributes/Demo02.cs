using System;
using System.Reflection;

[assembly: Red ]

[module: Green ]

public class App 
{
    static void Main() {
        Assembly asm = Assembly.LoadFrom("Demo02.exe");
        object [] atts = asm.GetCustomAttributes(typeof(RedAttribute), true);
        foreach(object o in atts) Console.WriteLine(o);
        Console.WriteLine("Demo02.exe annotated with Red = " + asm.IsDefined(typeof(RedAttribute), true));
        Console.WriteLine("Demo02.exe annotated with Red = " + asm.IsDefined(typeof(BlueAttribute), true));
        
        foreach(Type t in asm.GetTypes()){
            foreach(MemberInfo mi in t.GetMembers()){
                foreach(Object o in mi.GetCustomAttributes(true)){
                    Console.WriteLine("{0}::{1} -- {2}", t, mi.Name, o);
                }
            }
        }
    }
}

[AttributeUsage(AttributeTargets.Assembly)]
public sealed class RedAttribute : System.Attribute { }

[AttributeUsage(AttributeTargets.Module)]
public sealed class GreenAttribute : System.Attribute { }

[AttributeUsage(AttributeTargets.Class)]
public sealed class BlueAttribute : System.Attribute { }
public sealed class YellowAttribute : System.Attribute { }
public sealed class CyanAttribute : System.Attribute { }
public sealed class MagentaAttribute : System.Attribute { }
public sealed class BlackAttribute : System.Attribute { }

[Yellow]
[Blue]
public sealed class Widget
{
  
  [Black]
  // [Blue] -> só pode ser aplicado a classes
  [return: Cyan] 
  public int Splat([Magenta] int x ) {return 0;}
}

