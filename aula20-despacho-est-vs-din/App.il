
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.33440
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly App
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module App.exe
// MVID: {E4FE1C1E-C35B-4403-9A4B-C553AFEBE7E4}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00680000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Point
       extends [mscorlib]System.Object
{
  .field public int32 x
  .field public int32 y
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int32 x,
                               int32 y) cil managed
  {
    // Code size       24 (0x18)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  stfld      int32 Point::x
    IL_000f:  ldarg.0
    IL_0010:  ldarg.2
    IL_0011:  stfld      int32 Point::y
    IL_0016:  nop
    IL_0017:  ret
  } // end of method Point::.ctor

  .method public hidebysig instance void 
          Print() cil managed
  {
    // Code size       35 (0x23)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "[{0}, {1}]"
    IL_0006:  ldarg.0
    IL_0007:  ldfld      int32 Point::x
    IL_000c:  box        [mscorlib]System.Int32
    IL_0011:  ldarg.0
    IL_0012:  ldfld      int32 Point::y
    IL_0017:  box        [mscorlib]System.Int32
    IL_001c:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object,
                                                                  object)
    IL_0021:  nop
    IL_0022:  ret
  } // end of method Point::Print

  .method public hidebysig instance void 
          Dummy() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "Dummy"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method Point::Dummy

} // end of class Point

.class private auto ansi beforefieldinit App
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       11 (0xb)
    .maxstack  1
    .locals init (class Point V_0)
    IL_0000:  nop
    IL_0001:  ldnull
    IL_0002:  stloc.0
    IL_0003:  ldloc.0
    IL_0004:  call   instance void Point::Print()
    IL_0009:  nop
    IL_000a:  ret
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
// WARNING: Created Win32 resource file C:\MyFolder\ISEL\pg5 ave - 2015-2016 - 2º sem\aulas\aula20-despacho-est-vs-din\App.res
