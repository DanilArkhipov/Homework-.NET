module hw5.ResultBinder

let (>>=) x f = Result.bind f x
