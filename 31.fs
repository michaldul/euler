module Euler31

let rec count amount coins =
    match amount, coins with 
    | 0, _ -> 1
    | n, _ when n < 0 -> 0
    | _, [] -> 0
    | _, head :: tail -> count amount tail + count (amount - head) coins

printfn "%d" <| count 200 [200; 100; 50; 20; 10; 5; 2; 1]