
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.33440
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly 'Demo02-value-types-call'
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module 'Demo02-value-types-call.exe'
// MVID: {8CA575B2-1700-4CC7-8C66-1B3D36C48356}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00300000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit A
       extends [mscorlib]System.Object
{
  .method public hidebysig instance void 
          Print() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "A"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method A::Print

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method A::.ctor

} // end of class A

.class private sequential ansi sealed beforefieldinit S
       extends [mscorlib]System.ValueType
{
  .pack 0
  .size 1
  .method public hidebysig instance void 
          Print() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "S"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method S::Print

} // end of class S

.class private auto ansi beforefieldinit App
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       50 (0x32)
    .maxstack  1
    .locals init (class A V_0,
             valuetype S V_1,
             class [mscorlib]System.Type V_2)
    IL_0000:  nop
    IL_0001:  newobj     instance void A::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance void A::Print()
    IL_000d:  nop
    IL_000e:  ldloca.s   V_1
    IL_0010:  initobj    S
    IL_0016:  ldloca.s   V_1
    IL_0018:  call       instance void S::Print()
    IL_001d:  nop
    IL_001e:  ldloc.1
    IL_001f:  box        S
    IL_0024:  callvirt       instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_0029:  stloc.2
    IL_002a:  ldloc.2
    IL_002b:  call       void [mscorlib]System.Console::WriteLine(object)
    IL_0030:  nop
    IL_0031:  ret
  } // end of method App::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method App::.ctor

} // end of class App


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\MyFolder\ISEL\pg5 ave - 2015-2016 - 2º sem\aulas\aula21-despacho-est-vs-din\App.res
