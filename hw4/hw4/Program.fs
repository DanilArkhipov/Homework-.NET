namespace hw4

module program =

    [<EntryPoint>]
    let main argv =
        try
            let val1, op, val2 = Parser.parseArgs argv
            let result = Calculator.calculate val1 op val2
            printfn $"Result is: {result}"
            0
        with
        | Exceptions.WrongArgsLength message -> printfn $"%s{message}"; 1
        | Exceptions.WrongArgFormat message -> printfn $"%s{message}"; 2
        | Exceptions.WrongOperation message -> printfn $"%s{message}"; 3
        | Exceptions.DivisionByZero -> printfn "Division by zero"; 4