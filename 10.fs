module Euler10

open EulerCS

let main() = printf "%A" <| ((new ESieve(2000000)).GetPrimes() |> Seq.map (fun a -> bigint a) |> Seq.sum)

