type position = int * int
type tick = int

type Animal (pos : position, birthTicks : tick, maxAge : tick) = class
    // the data of an animal all has
    let mutable _remaindingBirthTicks = birthTicks
    let mutable _pos = (fst pos, snd pos)
    let mutable _age = 0
    member this.Pos = _pos
    member this.BirthTicks = birthTicks
    member this.RemaindingBirthTicks = _remaindingBirthTicks
    
    member this.Move(x,y) =
        _pos <- ((fst _pos) + x, (snd _pos) + y)
    
    member this.GiveBirth = 0
    member this.UpdateBirthTicks = _remaindingBirthTicks <- _remaindingBirthTicks - 1
    member this.ResetReproduction = _remaindingBirthTicks <- this.BirthTicks

    member this.MaxAge = maxAge
    member this.IncreaseAge = _age <- _age + 1
    member this.CheckAge =
        if _age = this.MaxAge then
            //kill this
            1
        else
            // Dont kill it
            0
end

type Moose(pos : position, birthTicks : tick, maxAge : tick) = class
    inherit Animal(pos, birthTicks, maxAge)
end

type Wolf(pos : position, birthTicks : tick, maxAge : tick, hungerTick : tick) = class
    inherit Animal(pos, birthTicks, maxAge)
    let mutable _hunger = hungerTick
    member this.Hunger = _hunger
    member this.HungerTick = hungerTick 

    member this.DecreaseHunger = _hunger - 1
    member this.ResetHunger = _hunger <- this.HungerTick
end

type Game() = class
    // Holds all game settings (like how many ticks and how many ticks per birth and so on)
end

type Board() = class
    let mooseList : Moose list = []
    let wolfList : Wolf list = []

    // Returns true if there is anything in that point
    member this.checkPoint(x,y) : bool =
        let mutable onefound = false
        for moose in mooseList do
            if (fst moose.Pos) = x then
                if (snd moose.Pos) = y then
                    onefound <- true
                
        
        for wolf in wolfList do
            if (fst wolf.Pos) = x then
                if (snd wolf.Pos) = y then
                    onefound <- true
        
        onefound
end