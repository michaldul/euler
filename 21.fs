let problem21 = 
    let d n = {1 .. n-1} |> Seq.filter (fun x -> n % x = 0) |> Seq.sum
    let amicable n = match d n with | dn -> n <> dn && n = d dn
    {1 .. 10000} |> Seq.filter amicable |> Seq.sum

problem21 |> printfn "%d"