open System.Collections.Generic

let memoize (f : 'a -> 'b) =
    let cache = new Dictionary<_,_>()
    fun (x : 'a) ->
        match cache.TryGetValue x with
        | (true, value) -> value
        | _ -> match f x with | y -> cache.Add(x,y); y

let rec count = memoize(fun n ->
    match n with 
    | 0 -> 1I
    | n when n < 0 -> 0I
    | n -> count (n - 1) + count (n - 2) + count (n - 3) + count (n - 4))

printfn "%A" <| count 50