
for tuple in queue do
    let beast = fst(tuple)
    let index = snd(tuple)
    if beast="w" then
      let wolf = _board.wolf.[index]
      let EatingPlaces = this.CheckEating( wolf.position )
      //printfn "%A" EatingPlaces
      if (EatingPlaces.Count = 0) then

        match wolf.tick() with
        | Some x ->
          wolf.resetReproduction()
        | None ->
          // check around for move
          let mutable moveValid : bool = false

          while not moveValid do
            let newPos = this.moveAnimal(wolf.position)

            if (this.checkValidMove(newPos)) then
              moveValid <- true
              wolf.position <- newPos
      else
        let attackChance = rnd.NextDouble()
        if (attackChance < attackPercent) then
          wolf.resetHunger()
          this.KillMooseFromPosition(Some (EatingPlaces.Item(0)))
          wolf.position <- Some (EatingPlaces.Item(0))

      wolf.updateReproduction()
      wolf.updateHunger()
    
    if beast="m" then
      let moose = _board.moose.[index]
      match moose.tick() with
      | Some x ->
        //printfn "Moose choosing to reproduce"
        let coords = [(0, -1); (-1, -1); (-1, 0); (-1, 1); (0, 1); (1, 1); (1, 0); (1, -1)]
        if Option.isSome moose.position then
          let posValue = Option.get moose.position
          //printfn "%A" posValue
          let mutable hasBeenBorn = false
          for i = 0 to (coords.Length - 1) do
            if this.checkValidMove(Some (fst posValue + fst coords.[i], snd posValue + snd coords.[i])) then
              if not hasBeenBorn then
                _board.moose <- x::_board.moose
                x.position <- Some (fst posValue + fst coords.[i], snd posValue + snd coords.[i])
                moose.resetReproduction()
                hasBeenBorn <- true
      | None ->
        //printfn "Moose chose to move!"
        let mutable moveValid : bool = false

        while not moveValid do
          let newPos = this.moveAnimal(moose.position)

          if (this.checkValidMove(newPos)) then
            moveValid <- true
            moose.position <- newPos
            moose.updateReproduction()
