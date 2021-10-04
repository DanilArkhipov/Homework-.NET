module Tests.ParserTests

open System
open Xunit
open hw4

[<Fact>]
let ``ParseOperation simple test`` () =
    Assert.Equal(Operation.Plus, Parser.parseOperation "+")
    Assert.Equal(Operation.Minus, Parser.parseOperation "-")
    Assert.Equal(Operation.Multiply, Parser.parseOperation "*")
    Assert.Equal(Operation.Divide, Parser.parseOperation "/")

[<Fact>]
let ``ParseOperation should throws WrongOperation`` () =
    let parseWrongOperation () =
        let a = Parser.parseArgs [|"1";"%";"2"|]
        printf $"%s{a.ToString()}"
    let action = Action parseWrongOperation
    Assert.Throws<Exceptions.WrongOperation>(action)

[<Fact>]
let ``ParseArgs simple test`` () =
    Assert.Equal((1., Operation.Plus, 2.), Parser.parseArgs [| "1";"+";"2" |])

[<Fact>]
let ``ParseArgs should throws WrongArgsLength`` () =
    let parseTwoArgs () =
        let a = Parser.parseArgs [|"1";"+"|]
        printf $"%s{a.ToString()}"
    let action = Action parseTwoArgs
    Assert.Throws<Exceptions.WrongArgsLength>(action)

[<Fact>]
let ``ParseArgs should throws WrongArgFormat`` () =
    let parseWrongArg1 () =
        let a = Parser.parseArgs [|"x";"+";"1"|]
        printf $"%s{a.ToString()}"
    let action1 = Action parseWrongArg1
    let _ = Assert.Throws<Exceptions.WrongArgFormat>(action1)

    let parseWrongArg2 () =
        let a = Parser.parseArgs [|"1";"+";"x"|]
        printf $"%s{a.ToString()}"
    let action2 = Action parseWrongArg2
    Assert.Throws<Exceptions.WrongArgFormat>(action2)