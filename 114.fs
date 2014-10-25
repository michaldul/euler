module Euler114

open Utils

let rec count = memoize(fun units ->
    match units with
    | n when n < 3I -> 1I
    | n -> count (n-1I) + ({ 3I..n } |> Seq.map (fun w -> count (n-w-1I)) |> Seq.sum))

printfn "%A" <| count 50I