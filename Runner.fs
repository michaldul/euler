module Runner

let stopWatch = System.Diagnostics.Stopwatch.StartNew()

Euler117.main()

stopWatch.Stop()
printfn "Time: %fs" stopWatch.Elapsed.TotalSeconds

ignore <| System.Console.ReadLine()