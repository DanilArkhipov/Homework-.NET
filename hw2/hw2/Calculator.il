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
    .maxstack 3

    ldarg.0
    conv.r8
    ldarg.2
    conv.r8

    ldarg.1

    switch (plus, minus, multiply, divide)

    plus: add
    ret
    minus: sub
    ret
    multiply: mul
    ret
    divide: div
    ret
  }
}