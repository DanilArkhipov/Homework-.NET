module hw5.Parser
open ResultBinder

let parseArgs (args:string[]) =
    let result = ResultBuilder()

    let checkArgsLength (args:string[]) =
        match args.Length with
        | 3 -> Ok args
        | _ -> Error $"3 arguments are required, but %i{args.Length} provided"

    let parseOperation (args : string[]) =
        result {
            let! operationResult =
                match args.[1] with
                | "+" -> Ok Operation.Plus
                | "-" -> Ok Operation.Minus
                | "*" -> Ok Operation.Multiply
                | "/" -> Ok Operation.Divide
                | _ -> Error $"Invalid operation: %s{args.[1]}"
            return args.[0], operationResult, args.[2]
        }

    let parseValue x =
        try
            Ok (x |> double)
        with
            _ -> Error $"Wrong argument format: {x}"

    let parseValues (val1:string, op, val2:string) =
        result {
            let! val11 = parseValue val1
            let! val22 = parseValue val2
            return val11, op, val22
        }

    args
    |> checkArgsLength
    >>= parseOperation
    >>= parseValues