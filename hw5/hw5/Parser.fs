module hw5.Parser
open ResultBinder

let parseArgs (args:string[]) =
    let checkArgsLength (args:string[]) =
        match args.Length with
        | 3 -> Ok args
        | _ -> Error $"3 arguments are required, but %i{args.Length} provided"

    let parseOperation (args : string[]) =
        let operationResult =
            match args.[1] with
            | "+" -> Ok Operation.Plus
            | "-" -> Ok Operation.Minus
            | "*" -> Ok Operation.Multiply
            | "/" -> Ok Operation.Divide
            | _ -> Error $"Invalid operation: %s{args.[1]}"
        let result = ResultBuilder()
        result {
            let! op = operationResult
            return args.[0], Ok op, args.[2]
        }

    let parseValue x =
        try
            Ok (x |> double)
        with
            _ -> Error $"Wrong argument format: {x}"

    let parseValues (val1:string, op, val2:string) =
        let result1 = parseValue val1
        let result2 = parseValue val2
        let result = ResultBuilder()
        result {
            let! val11 = result1
            let! val22 = result2
            return Ok val11, op, Ok val22
        }

    args
    |> checkArgsLength
    >>= parseOperation
    >>= parseValues