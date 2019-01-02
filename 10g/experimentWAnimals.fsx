[<EntryPoint>]
let main args= 
    if (args.Length <> 8) then 
        printfn "Not enough or to many arguments.\n Please see asigment for correct form, since this is the only sanitation being done."  
    else
        let game = animals.Game((args.[0] |> int) , args.[1] , (args.[2] |> int) , (args.[3] |> int) , (args.[4] |> int) , (args.[5] |> int) , (args.[6] |> int) , (args.[7] |> int))
        game.startGame()
    0