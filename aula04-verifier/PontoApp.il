
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.33440
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern Ponto
{
  .ver 0:0:0:0
}
.assembly PontoApp
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module PontoApp.exe
// MVID: {815F8A61-6EEF-48D1-BD8A-792198B4E574}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00570000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit PontoApp
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       48 (0x30)
    .maxstack  3
    .locals init (class [Ponto]Ponto V_0,
             string V_1)
    IL_0000:  nop
    IL_0001:  ldc.i4.5
    IL_0002:  ldc.i4.7
    IL_0003:  ldc.i4.s   9
    IL_0005:  newobj     instance void [Ponto]Ponto::.ctor(int32,
                                                           int32,
                                                           int32)
    IL_000a:  stloc.0
    IL_000b:  ldloc.0
    IL_000c:  callvirt   instance void [Ponto]Ponto::Print()
    IL_0011:  nop
    IL_0012:  ldstr      "p._x = {0}"
    IL_0017:  ldloc.0
    IL_0018:  ldfld      int32 [Ponto]Ponto::_x
    IL_001d:  box        [mscorlib]System.Int32
    IL_0022:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0027:  stloc.1
    IL_0028:  ldloc.1
    IL_0029:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_002e:  nop
    IL_002f:  ret
  } // end of method PontoApp::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method PontoApp::.ctor

} // end of class PontoApp


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\MyFolder\ISEL\pg5 ave - 2015-2016 - 2º sem\aulas\aula04\PontoApp.res
