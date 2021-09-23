.class public abstract sealed auto ansi beforefieldinit
  hw2.Parser
    extends System.Object
{
  .field public static literal int32 AllCorrect = int32(0)
  .field public static literal int32 WrongArgsLength = int32(1)
  .field public static literal int32 WrongArgFormat = int32(2)
  .field public static literal int32 WrongOperation = int32(3)

  .method public hidebysig static bool
    TryParseArgs(
      string[] args,
      [out] int32& val1,
      [out] valuetype hw2.Operation& operation,
      [out] int32& val2,
      [out] int32& resultCode
    ) cil managed
  {
    .maxstack 2

    // initialize to zero
    ldarg.s val1
    ldc.i4.0
    stind.i4

    ldarg.s operation
    ldc.i4.0
    stind.i4

    ldarg.s val2
    ldc.i4.0
    stind.i4

    ldarg.s resultCode
    ldc.i4.0
    stind.i4

    checkArgsLength: ldarg.s args
    call bool hw2.Parser::CheckArgsLength(string[])
    brtrue.s checkOperation
    ldarg.s resultCode
    ldc.i4.1 // WrongArgsLength
    stind.i4
    br.s return

    checkOperation: ldarg.s args
    ldc.i4.1
    ldelem.ref
    ldarg.s operation
    call bool hw2.Parser::TryParseOperation(string, valuetype hw2.Operation&)
    brtrue.s    checkValues
    ldarg.s resultCode
    ldc.i4.3 // WrongOperation
    stind.i4
    br.s return

    checkValues: ldarg.s args
    ldc.i4.0
    ldelem.ref
    ldarg.s val1
    call bool hw2.Parser::TryParseValue(string, int32&)
    brfalse.s IncorrectVal
    ldarg.s args
    ldc.i4.2
    ldelem.ref
    ldarg.s val2
    call bool hw2.Parser::TryParseValue(string, int32&)
    brtrue.s return

    IncorrectVal: ldarg.s resultCode
    ldc.i4.2 // WrongArgFormat
    stind.i4

    return: ldarg.s resultCode
    ldind.i4
    ldc.i4.0 // AllCorrect
    ceq
    ret
  }

  .method private hidebysig static bool
    CheckArgsLength(
      string[] args
    ) cil managed
  {
    .maxstack 2

    ldarg.0
    ldlen
    conv.i4
    ldc.i4.3
    ceq
    brfalse.s incorrect
    ldc.i4.1
    ret

    incorrect: ldstr "The program requires 3 CLI arguments but {0} provided"
    ldarg.0
    ldlen
    conv.i4
    box          [System.Runtime]System.Int32
    call         string [System.Runtime]System.String::Format(string, object)
    call         void [System.Console]System.Console::WriteLine(string)
    ldc.i4.0
    ret
  }

  .method private hidebysig static bool
    TryParseOperation(
      string arg,
      [out] valuetype hw2.Operation& operationAddress
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype hw2.Operation operation
    )

    ldarg.0
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Plus
    ldarg.0
    ldstr        "-"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Minus
    ldarg.0
    ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Multiply
    ldarg.0
    ldstr        "/"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     Divide
    br.s         Incorrect

    Plus: ldc.i4.0
    stloc.0
    br.s Asign

    Minus: ldc.i4.1
    stloc.0
    br.s Asign

    Multiply: ldc.i4.2
    stloc.0
    br.s Asign

    Divide: ldc.i4.3
    stloc.0
    br.s Asign

    Incorrect: ldc.i4.4
    stloc.0

    Asign:ldarg.1
    ldloc.0
    stind.i4

    ldarg.1
    ldind.i4
    ldc.i4.4
    ceq
    brtrue.s unsupported

    supported:
    ldc.i4.1
    ret

    unsupported:
    ldstr "Unsupported operation received: "
    ldarg.0
    call string [System.Runtime]System.String::Concat(string, string)
    call void [System.Console]System.Console::WriteLine(string)
    ldc.i4.0
    ret
  }

  .method private hidebysig static bool
    TryParseValue(
      string arg,
      [out] int32& val
    ) cil managed
  {
    .maxstack 2

    ldarg.0
    ldarg.1
    call bool [System.Runtime]System.Int32::TryParse(string, int32&)
    brtrue.s    isVal

    isNotVal: ldstr "Value is not int: "
    ldarg.0
    call string [System.Runtime]System.String::Concat(string, string)
    call void [System.Console]System.Console::WriteLine(string)
    ldc.i4.0
    ret

    isVal: ldc.i4.1      // isVal
    ret
  }
}