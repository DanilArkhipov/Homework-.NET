module Tests.CalculatorTests

open Xunit
open hw5

let result = ResultBuilder()

[<Theory>]
[<InlineData(5, Operation.Plus, 4, 9)>]
[<InlineData(5, Operation.Minus, 4, 1)>]
[<InlineData(5, Operation.Multiply, 4, 20)>]
[<InlineData(10, Operation.Divide, 2, 5)>]
let ``Int tests`` (val1, op, val2, expectedResult) =
    result {
        let! actual = Calculator.calculate (val1, op, val2)
        Assert.Equal(expectedResult, actual)
    }

[<Theory>]
[<InlineData(1.5, Operation.Plus, 2.1, 3.6)>]
[<InlineData(2.1, Operation.Minus, 1.5, 0.6)>]
[<InlineData(1.1, Operation.Multiply, 1.2, 1.32)>]
[<InlineData(1.5, Operation.Divide, 0.25, 6)>]
let ``Float tests`` (val1, op, val2, expectedResult) =
    result {
        let! actual = Calculator.calculate (val1, op, val2)
        Assert.Equal(expectedResult, actual)
    }

[<Theory>]
[<InlineData(0.123456789, Operation.Plus, 9.87654321, 9.999999999)>]
[<InlineData(9.87654321, Operation.Minus, 0.123456789, 9.753086421)>]
[<InlineData(1.12345, Operation.Multiply, 9.87654, 11.095798863)>]
[<InlineData(1.5, Operation.Divide, 0.25, 6)>]
let ``Double tests`` (val1, op, val2, expectedResult) =
    result {
        let! actual = Calculator.calculate (val1, op, val2)
        Assert.Equal(expectedResult, actual)
    }

[<Theory>]
[<InlineData(0.123456789101112, Operation.Plus, 0.876543212345678, 1.000000001446790)>]
[<InlineData(0.876543212345678, Operation.Minus, 0.123456789101112, 0.753086423244566)>]
[<InlineData(0.1234567, Operation.Multiply, 0.98765432, 0.121932543087944)>]
[<InlineData(0.121932543087944, Operation.Divide, 0.98765432, 0.1234567)>]
let ``Decimal tests`` (val1, op, val2, expectedResult) =
    result {
        let! actual = Calculator.calculate (val1, op, val2)
        Assert.Equal(expectedResult, actual)
    }

[<Fact>]
let ``Divide by zero`` () =
    let actual =
        Calculator.calculate (decimal 1, Operation.Divide, decimal 0)

    Assert.Equal(Error "Divide by zero", actual)
