module player

[<AbstractClass>]
type Player() =
    abstract member nextMove: (int * int) list
    
type Human() =
    inherit Player()

    member this.getCharAsNumber (place : char) : int =
        match place with
        | 'A' -> 0
        | 'B' -> 1
        | 'C' -> 2
        | 'D' -> 3
        | 'E' -> 4
        | 'F' -> 5
        | 'G' -> 6
        | 'H' -> 7
        | _ -> -1
    override this.nextMove : (int * int) list =
        
        let playerInput = string (System.Console.ReadLine())
        let exMove = (playerInput.ToLower().Split([|' '|]))
        if playerInput ="quit" then 
            [(-1, -1)]
        elif (playerInput.Length <> 5) || (exMove.Length <>2) then //<- Removes input of wrong format. 
            []
        elif (exMove.[0].Length <> 2 || exMove.[1].Length <> 2) then// <- removes errors of the length of the splittet input
            []
        else
            let firstChar = exMove.[0].[0]
            let secondChar = exMove.[1].[0]

            match System.Int32.TryParse(exMove.[0].[1].ToString()) with
            | (true,int1) -> 
              match System.Int32.TryParse(exMove.[1].[1].ToString()) with
              | (true,int2) ->
                let firstMove1 = this.getCharAsNumber (System.Char.ToUpper firstChar)
                if firstMove1 <> -1 then
                    let firstMove2 = int1 - 1
                    let secondMove1 = this.getCharAsNumber (System.Char.ToUpper secondChar)
                    if secondMove1 <> -1 then
                        let secondMove2 = int2 - 1
                        [(firstMove1, firstMove2); (secondMove1, secondMove2)]
                    else
                        []
                else
                  []
              | _ ->
                []
            | _ ->
              []