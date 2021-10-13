namespace hw5

type ResultBuilder() =
    member this.Bind(x, f) =
        match x with
        | Ok x -> f x
        | Error e -> Error e
    member this.Return(x) = Ok x