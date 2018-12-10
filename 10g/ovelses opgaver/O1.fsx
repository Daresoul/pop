type Car(ef : float) =
    let mutable _gas : float = 0.0
    member this.Effekt : float = ef
    member this.Gas
        with get () = _gas
        and set (value) = _gas <- value

    member this.AddGas (value) = _gas <- _gas + value
    member this.GasLeft = this.Gas

    member this.Drive (dist) =
        try
            let maxLen = this.Gas * this.Effekt
            
            if (maxLen > dist) then
                let gasUsed = dist / this.Effekt
                _gas <- this.Gas - gasUsed
                //this.Gas(this.Gas - gasUsed)
            else
                failwith ("Not enough gas for the distance")

        with
        |Failure (msg) -> printfn "Failed: %s" msg

let car = Car(100.0)
car.AddGas(100.0)
printfn "gas left: %f" car.GasLeft
car.Drive(1.0)
printfn "gas left: %f" car.GasLeft