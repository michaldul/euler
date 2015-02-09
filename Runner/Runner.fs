module Runner


let stopWatch = System.Diagnostics.Stopwatch.StartNew()

EulerCS.Problem12.Main()

stopWatch.Stop()
printfn "Time: %fs" stopWatch.Elapsed.TotalSeconds

ignore <| System.Console.ReadLine()