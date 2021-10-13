module hw5.Calculator

let calculate (val1, op, val2) =
    let divideBy bottom top =
        if bottom = decimal 0 then
            Error "Divide by zero"
        else
            Ok(top / bottom)

    let result = ResultBuilder()

    result {
        match op with
        | Operation.Plus -> return val1 + val2
        | Operation.Minus -> return val1 - val2
        | Operation.Multiply -> return val1 * val2
        | Operation.Divide ->
            let! r = val1 |> divideBy val2
            return r
    }