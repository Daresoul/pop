[<EntryPoint>]
let main args= 
    if (args.Length <> 8) then 
        printfn "Not enough or to many arguments.\n Please see asigment for correct form."
    elif ((args.[1].IndexOf(".txt")) = -1) then
        printfn "Second argument must end with .txt"  
   
    else
        for i in 0..7 do
            if (i <> 1) then
                match args.[i] |> System.Int32.TryParse with
                    | true, out -> 0
                    | _ -> failwithf "Argument nr. %d is not an integer\n\n" i 
            else 0
        
        if (((args.[2] |> int) < 1)) then
            printfn "Thrid argument must be above 0" 
        elif (((args.[3] |> int) < 1)) then
            printfn "Fourth argument must be above 0" 
        elif (((args.[4] |> int) < 1)) then
            printfn "Fifth argument must be above 0"  
        elif (((args.[5] |> int) < 1)) then
            printfn "Sixth argument must be above 0"    
        elif (((args.[6] |> int) < 1)) then
            printfn "Seventh argument must be above 0"   
        elif (((args.[7] |> int) < 1)) then
            printfn "Eight argument must be above 0"  
        else  //If the eight arguments passes the program runs. (Argument [0] can be any integer. By selecting 0 the program just outputs the start positions of the animals. If negative a blank file is created.)
            let game = animals.Game((args.[0] |> int) , args.[1] , (args.[2] |> int) , (args.[3] |> int) , (args.[4] |> int) , (args.[5] |> int) , (args.[6] |> int) , (args.[7] |> int))
            game.startGame()
    0

    //T = iterations, filDest = file destination, n = size of square sides, e = antal elge, fu = formenrings tid elge, u = antal ulve , fu = formerings tid ulve, s = sult tid  