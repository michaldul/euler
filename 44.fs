module Euler44

let isInteger x = x = (float (int32 x))
let isPentagonal x = isInteger ((sqrt (1. + 24. * float x) + 1.) / 6.)
let test (a, b) = isPentagonal (a - b) && isPentagonal (a + b)

let gen n = n * (3 * n - 1)/2
let pentagonalPairs = 
    seq { for n in 1 .. 1000000 do 
            for m in 1 .. n do 
                yield (gen n, gen m) }

match (Seq.find test pentagonalPairs) with | (a, b) -> printfn "%d" (a - b)