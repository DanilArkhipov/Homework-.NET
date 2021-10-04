module hw4.Parser

let checkArgsLength (args:string[]) = args.Length = 3

let parseOperation (s:string) =
    match s with
    | "+" -> Operation.Plus
    | "-" -> Operation.Minus
    | "*" -> Operation.Multiply
    | "/" -> Operation.Divide
    | _ -> raise (Exceptions.WrongOperation $"Invalid operation: %s{s}")

let parseArgs (args:string[]) =
    if checkArgsLength args <> true then
        raise (Exceptions.WrongArgsLength $"3 arguments are required, but %i{args.Length} provided")

    let val1 =
        try
            args.[0] |> double
        with
            | _ -> raise (Exceptions.WrongArgFormat $"Wrong argument format: %s{args.[0]}")
    let val2 =
        try
            args.[2] |> double
        with
            | _ -> raise (Exceptions.WrongArgFormat $"Wrong argument format: %s{args.[2]}")

    let op = parseOperation args.[1]
    val1, op, val2