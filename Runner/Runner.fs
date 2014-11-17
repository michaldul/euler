module Runner

let stopWatch = System.Diagnostics.Stopwatch.StartNew()

Euler53.main()

stopWatch.Stop()
printfn "Time: %fs" stopWatch.Elapsed.TotalSeconds

ignore <| System.Console.ReadLine()