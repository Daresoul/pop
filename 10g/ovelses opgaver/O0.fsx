type Counter() =
    let mutable _count = 0
    member this.Counter
        with get () = _count
    
    member this.Increase() = _count <- this.Counter + 1


let bob = Counter()
printfn "%i" bob.Counter
bob.Increase()
bob.Increase()
bob.Increase()
printfn "%i" bob.Counter