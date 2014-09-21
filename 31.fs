
let rec count amount coins =
    match amount, coins with 
    | 0, _ -> 1
    | _, coin :: tail -> 
        [ 0 .. amount/coin ] 
        |> List.map(fun n -> count (amount - n * coin) tail) 
        |> List.sum
    | _ -> 0

printfn "%d" <| count 200 [200; 100; 50; 20; 10; 5; 2; 1]