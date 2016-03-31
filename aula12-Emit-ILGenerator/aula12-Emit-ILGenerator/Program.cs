using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{

    const string ASM_NAME = "MyDynamic";

    static void Main(string[] args) 
    {
        Type klass = CreateDynamicType();
        FieldInfo fldNr = klass.GetField("nr");
        
        Object target = Activator.CreateInstance(klass);
        Console.WriteLine("instance of MyDynClass has nr = " + fldNr.GetValue(target));

        target = Activator.CreateInstance(klass, new object[1]{73});
        Console.WriteLine("instance of MyDynClass has nr = " + fldNr.GetValue(target));
    }
    static Type CreateDynamicType()
    {

        AssemblyName name = new AssemblyName(ASM_NAME);
        AssemblyBuilder asmBuilder =
            AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndSave);

        // For a single-module assembly, the module name is usually
        // the assembly name plus an extension.
        ModuleBuilder moduleBuilder = asmBuilder.DefineDynamicModule(ASM_NAME, ASM_NAME + ".dll");

        TypeBuilder klassBuilder = moduleBuilder.DefineType(
            "MyDynClass",
            TypeAttributes.Public);

        // Add a private field
        FieldBuilder fldNr = klassBuilder.DefineField(
            "nr", 
            typeof(int), 
            FieldAttributes.Public | FieldAttributes.InitOnly);

        // Add a constructor
        ConstructorBuilder ctor = klassBuilder.DefineConstructor(
            MethodAttributes.Public,
            CallingConventions.Standard,
            new Type[1] { typeof(int) });
        ILGenerator ctorIl = ctor.GetILGenerator();
        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Ldarg_1);
        ctorIl.Emit(OpCodes.Stfld, fldNr);
        ctorIl.Emit(OpCodes.Ret);

        // Add a Parameterless constructor
        ctor = klassBuilder.DefineConstructor(
            MethodAttributes.Public,
            CallingConventions.Standard,
            Type.EmptyTypes);
        ctorIl = ctor.GetILGenerator();
        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
        ctorIl.Emit(OpCodes.Ret);

        // Finish the type.
        Type klass = klassBuilder.CreateType();

        asmBuilder.Save(ASM_NAME + ".dll");

        return klass;
    }
}
