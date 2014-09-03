let problem06 = 
    let numbers = [1 .. 100]
    let sqr x = x * x
    let squaresSum = numbers |> List.map sqr |> List.sum
    let sumSquare = numbers |> List.sum |> sqr 
    sumSquare - squaresSum

printfn "%d" <| problem06