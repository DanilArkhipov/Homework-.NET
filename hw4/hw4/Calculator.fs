module hw4.Calculator

let calculate (val1:double) op (val2:double) =
    if op = Operation.Divide && val2 = 0. then
        raise Exceptions.DivisionByZero
    match op with
    | Plus -> val1 + val2
    | Minus -> val1 - val2
    | Multiply -> val1 * val2
    | Divide -> val1 / val2