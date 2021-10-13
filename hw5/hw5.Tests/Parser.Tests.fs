module Tests.ParserTests

open Xunit
open hw5

let result = ResultBuilder()

[<Fact>]
let ``When everything is correct`` () =
    Assert.Equal(Ok(decimal 1, Operation.Plus, decimal 2), Parser.parseArgs [| "1"; "+"; "2" |])
    Assert.Equal(Ok(decimal 1, Operation.Minus, decimal 2), Parser.parseArgs [| "1"; "-"; "2" |])
    Assert.Equal(Ok(decimal 1, Operation.Multiply, decimal 2), Parser.parseArgs [| "1"; "*"; "2" |])
    Assert.Equal(Ok(decimal 1, Operation.Divide, decimal 2), Parser.parseArgs [| "1"; "/"; "2" |])

[<Fact>]
let ``When args.Length isn't 3`` () =
    Assert.Equal(Error "3 arguments are required, but 2 provided", Parser.parseArgs [| "1"; "+" |])

[<Fact>]
let ``When operation is invalid`` () =
    Assert.Equal(Error "Invalid operation: %", Parser.parseArgs [| "1"; "%"; "2" |])

[<Fact>]
let ``When operands are invalid`` () =
    Assert.Equal(Error "Wrong argument format: a", Parser.parseArgs [| "a"; "+"; "2" |])
    Assert.Equal(Error "Wrong argument format: a", Parser.parseArgs [| "1"; "+"; "a" |])

[<Fact>]
let ``Correct with float numbers`` () =
    Assert.Equal(Ok(decimal 2.5, Operation.Plus, decimal 0.6), Parser.parseArgs [| "2.5"; "+"; "0.6" |])
