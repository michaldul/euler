module Runner


let stopWatch = System.Diagnostics.Stopwatch.StartNew()

EulerCS.Problem3.Main()

stopWatch.Stop()
printfn "Time: %fs" stopWatch.Elapsed.TotalSeconds

ignore <| System.Console.ReadLine()