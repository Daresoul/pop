type Moth (mothStartPos : float * float, lightPos : float * float) =
    let mutable _pos : float * float = mothStartPos

    member this.lightPos = lightPos
    member this.Pos
        with get () = _pos
        and set (value) = _pos <- value
    member this.GetAngle =
        let m = ((fst this.lightPos) - (fst this.Pos)) / ((snd this.lightPos) - (snd this.Pos))
        let angle = atan(m)
        
        angle * (180.0 / 3.14159265358979323846264338327950288419716939937510582097494459230781640628620899862803482534211706798214808651328230664709384460955058223172535940812848111745028410270193852110555964462294895493038196442881097566593344612847564823378678316527120190914564856692346034861045432664821339360726024914127372458700660631558817488152092096282925409171536436789259036001133053054882046652138414695194151160943305727036575959195309218611738193261179310511854807446237996274956735188575272489122793818301194912983367336244065664308602139494639522473719070217986094370277053921717629317675238467481846766940513200056812714526356082778577134275778960917363717872146844090122495343014) //+ 1.570796326794896476912

    member this.Speed =

        let deltax : float = ((fst this.lightPos) - (fst this.Pos)) ** 2.0
        let deltay : float = ((snd this.lightPos) - (snd this.Pos)) ** 2.0
        (sqrt (deltax + deltay)) / 2.0
    
    member this.MoveToLight =
        let angle = this.GetAngle
        printfn "angle: %.16f" angle
        let speed = this.Speed
        printfn "speed: %f" speed

        let dx = (cos (angle)) * speed
        let dy = (sin (angle)) * speed

        _pos <- ((fst this.Pos) + dx, (snd this.Pos) + dy)

let moth = Moth((0.0,0.0), (10000.0, 10000.0))
printfn "pos: %A" moth.Pos
moth.MoveToLight
printfn "pos: %A" moth.Pos