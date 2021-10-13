module hw5.Calculator

let calculate (val1, op, val2) =
    let divideBy bottom top =
        if bottom = double 0
        then Error "Divide by zero"
        else Ok (top / bottom)

    let result = ResultBuilder()

    result {
        let! val11 = val1
        let! val22 = val2
        match! op with
        | Plus -> return val11 + val22
        | Minus -> return val11 - val22
        | Multiply -> return val11 * val22
        | Divide -> let! r = val11 |> divideBy val22
                    return r
    }