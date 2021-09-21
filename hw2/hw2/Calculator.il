.class public abstract sealed auto ansi beforefieldinit
  hw2.Calculator
    extends System.Object
{

  .method public hidebysig static float64
    Calculate(
      int32 val1,
      valuetype hw2.Operation operation,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 V_0,
      [1] float64 V_1
    )

    // [16 13 - 22 15]
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    IL_0005: ldarg.1      // operation
    IL_0006: switch       (IL_001d, IL_0023, IL_0029, IL_002f)
    IL_001b: br.s         IL_0035

    // [18 35 - 18 46]
    IL_001d: ldarg.0      // val1
    IL_001e: ldarg.2      // val2
    IL_001f: add
    IL_0020: stloc.0      // V_0
    IL_0021: br.s         IL_0045

    // [19 36 - 19 47]
    IL_0023: ldarg.0      // val1
    IL_0024: ldarg.2      // val2
    IL_0025: sub
    IL_0026: stloc.0      // V_0
    IL_0027: br.s         IL_0045

    // [20 39 - 20 50]
    IL_0029: ldarg.0      // val1
    IL_002a: ldarg.2      // val2
    IL_002b: mul
    IL_002c: stloc.0      // V_0
    IL_002d: br.s         IL_0045

    // [21 37 - 21 48]
    IL_002f: ldarg.0      // val1
    IL_0030: ldarg.2      // val2
    IL_0031: div
    IL_0032: stloc.0      // V_0
    IL_0033: br.s         IL_0045
    IL_0035: ldc.i4.1
    IL_0036: brtrue.s     IL_0039

    // [16 30 - 22 14]
    IL_0038: nop

    IL_0039: ldarg.1      // operation
    IL_003a: box          hw2.Operation
    IL_003f: newobj       instance void [System.Runtime]System.Runtime.CompilerServices.SwitchExpressionException::.ctor(object)
    IL_0044: throw

    IL_0045: ldc.i4.1
    IL_0046: brtrue.s     IL_0049

    // [16 13 - 22 15]
    IL_0048: nop

    IL_0049: ldloc.0      // V_0
    IL_004a: conv.r8
    IL_004b: stloc.1      // V_1
    IL_004c: br.s         IL_004e

    // [23 9 - 23 10]
    IL_004e: ldloc.1      // V_1
    IL_004f: ret

  } // end of method Calculator::Calculate
}