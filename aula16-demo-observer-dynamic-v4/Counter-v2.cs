using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;

public interface Subscriber{
    void Update(int nr);
}


[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class SubscriberHandler : Attribute {
    /*
     * Order must be a valid number between [0, total handlers - 1]
     */
    public int Order{get; set; }
    public SubscriberHandler(int order) {
        this.Order = order;
    }
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
    
    /*
     * Retorna os métodos de klass compatíveis com o método Subscriber::Update
     * e que estejam anotados com SubscriberHandler
     */
    private IEnumerable<MethodInfo> GetValidHandlers(Type klass) {
        SortedDictionary<int, MethodInfo> ms = new SortedDictionary<int, MethodInfo>();
        foreach(MethodInfo m in klass.GetMethods()) {
            object[] atts = m.GetCustomAttributes(typeof(SubscriberHandler), true);
            if(atts != null && atts.Length != 0) { 
                ParameterInfo[] ps = m.GetParameters();
                if( ps.Length == 1 && ps[0].ParameterType == typeof(int) )
                {
                    SubscriberHandler a = (SubscriberHandler) atts[0];
                    ms.Add(a.Order, m);
                }
            }
        }
        return ms.Values;
    }    
    /*
     * Adiciona dinamicamente todos os métodos compatíveis com Subscriber::Update
     */
    public void AddSubscriberDynamicByEmit(object target) 
    {
        if(target == null) return;
        foreach(MethodInfo m in GetValidHandlers(target.GetType())) {
            subs.Add(SubscriberBuilder.NewSubscriber(target, m));
        }
    }

    /*
     * Adiciona dinamicamente todos os métodos compatíveis com Subscriber::Update
     */
    public void AddSubscriberDynamic(object target) 
    {
        if(target == null) return;
        foreach(MethodInfo m in GetValidHandlers(target.GetType())) {
            subs.Add(new SubscriberWrapper(target, m));
        }
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

class SubscriberWrapper : Subscriber 
{
    private readonly object target;
    private readonly MethodInfo handler;
    public SubscriberWrapper(object t, MethodInfo h) {target = t; handler = h;}
    public void Update(int nr) {
        handler.Invoke(target, new object[1]{nr});
    }
}

class SubscriberBuilder 
{
    public static Subscriber NewSubscriber(object target, MethodInfo handler) {
        string prefix = target.GetType().Name + handler.Name;
        string asmName =  prefix + "Handlers";
        string klassName = prefix + "Klass";
        AssemblyBuilder asmBuilder;
        TypeBuilder klassBuilder = CreateType(asmName, klassName, out asmBuilder);
        
        // Implementar a interface Subscriber
        klassBuilder.AddInterfaceImplementation(typeof(Subscriber));
        
        // Add a private field
        FieldBuilder fldTarget = klassBuilder.DefineField(
            "target", 
            typeof(object), 
            FieldAttributes.Private | FieldAttributes.InitOnly);

        AddCtor(klassBuilder, fldTarget);
        
        // Adcionar o método Update
        AddUpdateMethod(klassBuilder, handler, fldTarget);
        
        // Finish the type
        Type klass = klassBuilder.CreateType();

        asmBuilder.Save(asmName + ".dll");
        
        return (Subscriber) Activator.CreateInstance(klass, new object[]{target});
    }

    private static void AddCtor(TypeBuilder klassBuilder, FieldBuilder fldTarget) {  
            // Add a constructor
        ConstructorBuilder ctor = klassBuilder.DefineConstructor(
            MethodAttributes.Public,
            CallingConventions.Standard,
            new Type[1] { typeof(object) });
            
        ILGenerator ctorIl = ctor.GetILGenerator();
        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Ldarg_1);
        ctorIl.Emit(OpCodes.Stfld, fldTarget);
        ctorIl.Emit(OpCodes.Ret);
    }
    
    private static void AddUpdateMethod(TypeBuilder klassBuilder, MethodInfo handler, FieldBuilder fldTarget) {
        MethodBuilder mb = klassBuilder.DefineMethod(
            "Update",
            MethodAttributes.Virtual | MethodAttributes.Public | MethodAttributes.ReuseSlot,
            typeof(void),
            new Type[1]{typeof(int)}
        );
        ILGenerator il = mb.GetILGenerator();
        if(!handler.IsStatic) {
            il.Emit(OpCodes.Ldarg_0);          // push this
            il.Emit(OpCodes.Ldfld, fldTarget); // push field target
        }
        il.Emit(OpCodes.Ldarg_1);       // push arg 1
        il.Emit(OpCodes.Call, handler); // call 
        il.Emit(OpCodes.Ret);           // ret
    }
    
    private static TypeBuilder CreateType(
        string asmName, 
        string klassName,
        out AssemblyBuilder asmBuilder) 
    {
        AssemblyName name = new AssemblyName(asmName);
        asmBuilder =
            AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndSave);

        // For a single-module assembly, the module name is usually
        // the assembly name plus an extension.
        ModuleBuilder moduleBuilder = asmBuilder.DefineDynamicModule(asmName, asmName + ".dll");

        TypeBuilder klassBuilder = moduleBuilder.DefineType(
            klassName,
            TypeAttributes.Public);
        
        return klassBuilder;
    }
}
