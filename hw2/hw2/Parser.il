.class public abstract sealed auto ansi beforefieldinit
  hw2.Parser
    extends System.Object
{

  .field public static literal int32 AllCorrect = int32(0) // 0x00000000

  .field public static literal int32 WrongArgsLength = int32(1) // 0x00000001

  .field public static literal int32 WrongArgFormat = int32(2) // 0x00000002

  .field public static literal int32 WrongOperation = int32(3) // 0x00000003

  .method private hidebysig static bool
    CheckArgsLength(
      string[] args
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )

    // [13 9 - 13 10]
    IL_0000: nop

    // [14 13 - 14 34]
    IL_0001: ldarg.0      // args
    IL_0002: ldlen
    IL_0003: conv.i4
    IL_0004: ldc.i4.3
    IL_0005: ceq
    IL_0007: stloc.0      // V_0

    IL_0008: ldloc.0      // V_0
    IL_0009: brfalse.s    IL_0010

    // [15 13 - 15 14]
    IL_000b: nop

    // [16 17 - 16 29]
    IL_000c: ldc.i4.1
    IL_000d: stloc.1      // V_1
    IL_000e: br.s         IL_002c

    // [19 13 - 19 99]
    IL_0010: ldstr        "The program requires 3 CLI arguments but {0} provided"
    IL_0015: ldarg.0      // args
    IL_0016: ldlen
    IL_0017: conv.i4
    IL_0018: box          [System.Runtime]System.Int32
    IL_001d: call         string [System.Runtime]System.String::Format(string, object)
    IL_0022: call         void [System.Console]System.Console::WriteLine(string)
    IL_0027: nop

    // [20 13 - 20 26]
    IL_0028: ldc.i4.0
    IL_0029: stloc.1      // V_1
    IL_002a: br.s         IL_002c

    // [21 9 - 21 10]
    IL_002c: ldloc.1      // V_1
    IL_002d: ret

  } // end of method Parser::CheckArgsLength

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
    .locals init (
      [0] bool V_0,
      [1] bool V_1,
      [2] bool V_2,
      [3] bool V_3
    )

    // [25 9 - 25 10]
    IL_0000: nop

    // [26 13 - 26 33]
    IL_0001: ldarg.2      // operation
    IL_0002: ldc.i4.0
    IL_0003: stind.i4

    // [27 13 - 27 28]
    IL_0004: ldarg.1      // val1
    IL_0005: ldc.i4.0
    IL_0006: stind.i4

    // [28 13 - 28 28]
    IL_0007: ldarg.3      // val2
    IL_0008: ldc.i4.0
    IL_0009: stind.i4

    // [29 13 - 29 37]
    IL_000a: ldarg.s      resultCode
    IL_000c: ldc.i4.0
    IL_000d: stind.i4

    // [31 13 - 31 40]
    IL_000e: ldarg.0      // args
    IL_000f: call         bool hw2.Parser::CheckArgsLength(string[])
    IL_0014: ldc.i4.0
    IL_0015: ceq
    IL_0017: stloc.0      // V_0

    IL_0018: ldloc.0      // V_0
    IL_0019: brfalse.s    IL_0023

    // [32 13 - 32 14]
    IL_001b: nop

    // [33 17 - 33 46]
    IL_001c: ldarg.s      resultCode
    IL_001e: ldc.i4.1
    IL_001f: stind.i4

    // [34 13 - 34 14]
    IL_0020: nop

    IL_0021: br.s         IL_005f

    // [35 18 - 35 65]
    IL_0023: ldarg.0      // args
    IL_0024: ldc.i4.1
    IL_0025: ldelem.ref
    IL_0026: ldarg.2      // operation
    IL_0027: call         bool hw2.Parser::TryParseOperation(string, valuetype hw2.Operation&)
    IL_002c: ldc.i4.0
    IL_002d: ceq
    IL_002f: stloc.1      // V_1

    IL_0030: ldloc.1      // V_1
    IL_0031: brfalse.s    IL_003b

    // [36 13 - 36 14]
    IL_0033: nop

    // [37 17 - 37 45]
    IL_0034: ldarg.s      resultCode
    IL_0036: ldc.i4.3
    IL_0037: stind.i4

    // [38 13 - 38 14]
    IL_0038: nop

    IL_0039: br.s         IL_005f

    // [39 18 - 39 93]
    IL_003b: ldarg.0      // args
    IL_003c: ldc.i4.0
    IL_003d: ldelem.ref
    IL_003e: ldarg.1      // val1
    IL_003f: call         bool hw2.Parser::TryParseValue(string, int32&)
    IL_0044: brfalse.s    IL_0054
    IL_0046: ldarg.0      // args
    IL_0047: ldc.i4.2
    IL_0048: ldelem.ref
    IL_0049: ldarg.3      // val2
    IL_004a: call         bool hw2.Parser::TryParseValue(string, int32&)
    IL_004f: ldc.i4.0
    IL_0050: ceq
    IL_0052: br.s         IL_0055
    IL_0054: ldc.i4.1
    IL_0055: stloc.2      // V_2

    IL_0056: ldloc.2      // V_2
    IL_0057: brfalse.s    IL_005f

    // [40 13 - 40 14]
    IL_0059: nop

    // [41 17 - 41 45]
    IL_005a: ldarg.s      resultCode
    IL_005c: ldc.i4.2
    IL_005d: stind.i4

    // [42 13 - 42 14]
    IL_005e: nop

    // [44 13 - 44 45]
    IL_005f: ldarg.s      resultCode
    IL_0061: ldind.i4
    IL_0062: ldc.i4.0
    IL_0063: ceq
    IL_0065: stloc.3      // V_3
    IL_0066: br.s         IL_0068

    // [45 9 - 45 10]
    IL_0068: ldloc.3      // V_3
    IL_0069: ret

  } // end of method Parser::TryParseArgs

  .method private hidebysig static bool
    TryParseOperation(
      string arg,
      [out] valuetype hw2.Operation& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool isOperation,
      [1] valuetype hw2.Operation V_1,
      [2] bool V_2,
      [3] bool V_3
    )

    // [48 9 - 48 10]
    IL_0000: nop

    // [49 13 - 56 15]
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    // [49 29 - 56 14]
    IL_0004: nop

    IL_0005: ldarg.0      // arg
    IL_0006: ldstr        "+"
    IL_000b: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0010: brtrue.s     IL_003b
    IL_0012: ldarg.0      // arg
    IL_0013: ldstr        "-"
    IL_0018: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_003f
    IL_001f: ldarg.0      // arg
    IL_0020: ldstr        "*"
    IL_0025: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0043
    IL_002c: ldarg.0      // arg
    IL_002d: ldstr        "/"
    IL_0032: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_0047
    IL_0039: br.s         IL_004b

    // [51 24 - 51 38]
    IL_003b: ldc.i4.0
    IL_003c: stloc.1      // V_1
    IL_003d: br.s         IL_004f

    // [52 24 - 52 39]
    IL_003f: ldc.i4.1
    IL_0040: stloc.1      // V_1
    IL_0041: br.s         IL_004f

    // [53 24 - 53 42]
    IL_0043: ldc.i4.2
    IL_0044: stloc.1      // V_1
    IL_0045: br.s         IL_004f

    // [54 24 - 54 40]
    IL_0047: ldc.i4.3
    IL_0048: stloc.1      // V_1
    IL_0049: br.s         IL_004f

    // [55 22 - 55 50]
    IL_004b: ldc.i4.4
    IL_004c: stloc.1      // V_1
    IL_004d: br.s         IL_004f

    IL_004f: ldc.i4.1
    IL_0050: brtrue.s     IL_0053

    // [49 13 - 56 15]
    IL_0052: nop

    IL_0053: ldarg.1      // operation
    IL_0054: ldloc.1      // V_1
    IL_0055: stind.i4

    // [57 13 - 57 77]
    IL_0056: ldarg.1      // operation
    IL_0057: ldind.i4
    IL_0058: ldc.i4.4
    IL_0059: ceq
    IL_005b: ldc.i4.0
    IL_005c: ceq
    IL_005e: stloc.0      // isOperation

    // [58 13 - 58 30]
    IL_005f: ldloc.0      // isOperation
    IL_0060: ldc.i4.0
    IL_0061: ceq
    IL_0063: stloc.2      // V_2

    IL_0064: ldloc.2      // V_2
    IL_0065: brfalse.s    IL_007a

    // [59 13 - 59 14]
    IL_0067: nop

    // [60 17 - 60 77]
    IL_0068: ldstr        "Unsupported operation received: "
    IL_006d: ldarg.0      // arg
    IL_006e: call         string [System.Runtime]System.String::Concat(string, string)
    IL_0073: call         void [System.Console]System.Console::WriteLine(string)
    IL_0078: nop

    // [61 13 - 61 14]
    IL_0079: nop

    // [63 13 - 63 32]
    IL_007a: ldloc.0      // isOperation
    IL_007b: stloc.3      // V_3
    IL_007c: br.s         IL_007e

    // [64 9 - 64 10]
    IL_007e: ldloc.3      // V_3
    IL_007f: ret

  } // end of method Parser::TryParseOperation

  .method private hidebysig static bool
    TryParseValue(
      string arg,
      [out] int32& val
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool isVal,
      [1] bool V_1,
      [2] bool V_2
    )

    // [67 9 - 67 10]
    IL_0000: nop

    // [68 13 - 68 52]
    IL_0001: ldarg.0      // arg
    IL_0002: ldarg.1      // val
    IL_0003: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0008: stloc.0      // isVal

    // [69 13 - 69 24]
    IL_0009: ldloc.0      // isVal
    IL_000a: ldc.i4.0
    IL_000b: ceq
    IL_000d: stloc.1      // V_1

    IL_000e: ldloc.1      // V_1
    IL_000f: brfalse.s    IL_0024

    // [70 13 - 70 14]
    IL_0011: nop

    // [71 17 - 71 63]
    IL_0012: ldstr        "Value is not int: "
    IL_0017: ldarg.0      // arg
    IL_0018: call         string [System.Runtime]System.String::Concat(string, string)
    IL_001d: call         void [System.Console]System.Console::WriteLine(string)
    IL_0022: nop

    // [72 13 - 72 14]
    IL_0023: nop

    // [74 13 - 74 26]
    IL_0024: ldloc.0      // isVal
    IL_0025: stloc.2      // V_2
    IL_0026: br.s         IL_0028

    // [75 9 - 75 10]
    IL_0028: ldloc.2      // V_2
    IL_0029: ret

  } // end of method Parser::TryParseValue
}