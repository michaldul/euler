module Utils

open System.Collections.Generic

let memoize (f : 'a -> 'b) =
    let dict = new Dictionary<_,_>()
    fun (n : 'a) ->
        match dict.TryGetValue(n) with
        | (true, v) -> v
        | _ ->
            let temp = f(n)
            dict.Add(n, temp)
            temp