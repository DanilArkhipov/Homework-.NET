module Tests.CalculatorTests

open System
open Xunit
open hw4

[<Fact>]
let ``Simple tests`` () =
    Assert.Equal(Calculator.calculate 1. Operation.Plus 2., 3.)
    Assert.Equal(Calculator.calculate 3. Operation.Minus 1., 2.)
    Assert.Equal(Calculator.calculate 4. Operation.Multiply 5., 20.)
    Assert.Equal(Calculator.calculate 36. Operation.Divide 4., 9.)

[<Fact>]
let ``Division by zero test`` () =
    let divideByZero () = printf $"%f{Calculator.calculate 1. Operation.Divide 0.}"
    let action = Action divideByZero
    Assert.Throws<Exceptions.DivisionByZero>(action)