module Euler53

open Utils
open NUnit.Framework
open FsUnit

let rec choose = memoize(
     fun (n, k) -> match k with 
            | _ when k <= 0I -> 1I 
            | _ when n = k -> 1I 
            | _ -> choose (n-1I, k-1I) + choose (n-1I, k))
    
let genPairs n = seq { for x in 1 .. n do
                        for y in 1 .. x -> x, y }

let main() = 
    genPairs 100 
    |> Seq.map (fun (a, b) -> bigint a, bigint b) 
    |> Seq.map choose 
    |> Seq.filter (fun n -> n > 1000000I) 
    |> Seq.length |> printfn "%A"
    
[<Test>]
let ``choose 2 2 equals 1``() =
    choose (2I, 2I) |> should equal 1I

[<Test>]
let ``choose 3 1 equals 3``() =
    choose (3I, 1I) |> should equal 3I

[<Test>]
let ``choose 5 2 equals 10``() =
    choose (5I, 2I) |> should equal 10I

[<Test>]
let ``genPairs returns n*(n+1)/2 pairs``() =
    genPairs 9 |> Seq.toList |> should haveLength 45