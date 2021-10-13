module hw5.Program

open ResultBinder

let printResult r =
    match r with
    | Ok x -> printf $"Result is {x}"
    | Error e -> printf $"{e}"

[<EntryPoint>]
let main argv =
    let result =
        argv
        |> Parser.parseArgs
        >>= Calculator.calculate

    printResult result
    0