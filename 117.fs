open System.Collections.Generic

let memoize (f : 'a -> 'b) =
    let cache = new Dictionary<_,_>()
    fun (x : 'a) ->
        match cache.TryGetValue x with
        | (true, value) -> value
        | _ -> match f x with | y -> cache.Add(x,y); y

let rec count = memoize(fun n ->
    match n with 
    | 0 | 1 -> 1I
    | 2 -> 2I
    | 3 -> 4I
    | n -> count (n - 1) + count (n - 2) + count (n - 3) + count (n - 4))

printfn "%A" <| count 50