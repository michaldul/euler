let rec isPalindrome lst =
    match lst with 
    | [_] | [] -> true
    | h :: t when List.head (List.rev t) = h -> isPalindrome <| List.tail (List.rev t)
    | _ -> false

let rec reversedDigits b n =
    match n with 
    | 0 -> [] 
    | _ -> n % b :: reversedDigits b (n / b)

let sum = 
    {1..1000000}  
    |> Seq.filter (fun n -> isPalindrome (reversedDigits 2 n) && isPalindrome (reversedDigits 10 n))
    |> Seq.sum

printfn "%d" sum