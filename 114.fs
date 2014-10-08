
open System.Collections.Generic

let memoize (f : 'a -> 'b) =
    let cache = new Dictionary<_,_>()
    fun (x : 'a) ->
        match cache.TryGetValue x with
        | (true, value) -> value
        | _ -> match f x with | y -> cache.Add(x,y); y

let rec count = memoize(fun units ->
    match units with
    | n when n < 3I -> 1I
    | n -> count (n-1I) + ({ 3I..n } |> Seq.map (fun w -> count (n-w-1I)) |> Seq.sum))

printfn "%A" <| count 50I