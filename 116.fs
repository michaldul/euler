
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
 
let rec choose = memoize(fun (n, k) ->
    match n, k with 
    | _, k when k = 0I-> 1I
    | _ when k = n -> 1I
    | _ -> choose (n-1I, k-1I) + choose (n-1I, k))

let countCombination color tiles =
    {1I .. tiles/color} 
    |> Seq.map (fun colorTiles -> match tiles - colorTiles * color with 
        | blackTiles -> choose (blackTiles + colorTiles, colorTiles) )
    |> Seq.sum

let countRed = countCombination 2I
let countGreen = countCombination 3I
let countBlue = countCombination 4I

let result = countRed 50I + countGreen 50I + countBlue 50I

printfn "%A" result