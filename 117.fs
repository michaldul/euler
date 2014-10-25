module Euler117

open Utils

let rec count = memoize(fun n ->
    match n with 
    | 0 -> 1I
    | n when n < 0 -> 0I
    | n -> count (n - 1) + count (n - 2) + count (n - 3) + count (n - 4))

let main() = printfn "%A" <| count 50