
let uniqueDivisors n =
    let divisors = Array.create (n+1) 0
    seq { for i in 2 .. n do 
            match divisors.[i] with 
            | 0 -> 
                {i .. i .. n} |> Seq.iter (fun n -> divisors.[n] <- divisors.[n] + 1)
                yield (i, 1)
            | d -> 
                yield (i, d) }

let rec findConsecutive list = 
    match list with 
    | a :: _ :: _ :: b :: _ when b - a = 3 -> a
    | _ :: tail -> findConsecutive tail
    | [] -> failwith "not found"

uniqueDivisors 1000000 
    |> List.ofSeq
    |> List.filter (fun (n, c) -> c = 4) 
    |> List.map (fun (n, c) -> n)
    |> findConsecutive
    |> printfn "%d"
