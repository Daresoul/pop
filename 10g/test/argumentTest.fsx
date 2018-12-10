[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    printfn "First arg is : %A" args.[0]
    printfn "First arg is : %A" args.[args.Length - 1]
    // Return 0. This indicates success.
    0