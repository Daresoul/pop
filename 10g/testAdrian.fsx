
let T = 10
let s = 10
let u = 2
let e = 8
let n = 16
let f_elg = 10
let f_ulv = 10

type spot = int * int

[<AbstractClass>]
type Beast(a: spot) =
    let mutable b = a
    member this.At
        with get() = b
        and set(c) = b <- c
    abstract member Is: string
    member this.Move = 1
    member this.Birth = 1

type Wolf(a: spot) =
    inherit Beast(a)
    override this.Is = "Wolf"

type Elk(a: spot) =
    inherit Beast(a)
    override this.Is = "Elk"

let any = System.Random()
let mutable someSpot = (any.Next(0, n), any.Next(0, n))

let mutable queue: Beast list = []

let getSpot (a: Beast list) =
    let mutable r = []
    for i in a do
        r <- i.At :: r
    List.rev r

let getString (a: Beast list) =
    let mutable r = []
    for i in a do
        r <- i.Is :: r
    List.rev r

let isFree (a: spot) =
    List.contains a (getSpot queue)

let spawn beast amount =
    for i=1 to amount do
        let mutable keepOn = true
        while keepOn=true do
            someSpot <- (any.Next(0, n), any.Next(0, n))
            if (isFree someSpot)=false then
                keepOn <- false
        let uc = beast(someSpot) :> Beast
        queue <- uc :: queue

spawn Wolf u
spawn Elk e

let mix (a: Beast list) =
    let mutable b = a
    let mutable r = []
    let End = a.Length
    for i=1 to End do
        let j = any.Next(0, b.Length)
        r <- b.[j] :: r
        b <- List.filter (fun x -> not(x=b.[j])) b
    r

let hunt (a: Beast) =
    if a :? Wolf then
        1
    else
        0

let anyAct (a: Beast) =
    let x = any.Next(0, 3)
    match x with
        | 0 -> a.Move
        | 1 -> a.Birth
        | 2 -> hunt a
        | _ -> 0

queue <- mix queue

printfn "%A" (getString queue)