let numberOfRectangles n m = (n + 1I) * n * (m + 1I) * m / 4I

let rectangles = 
    seq { for i in { 1I .. 1000I } do
            for j in { 1I .. i } do
                match numberOfRectangles i j with 
                | x -> yield ((i, j), abs (2000000I - x)) }

let solution = Seq.minBy snd rectangles

printfn "%A" <| solution