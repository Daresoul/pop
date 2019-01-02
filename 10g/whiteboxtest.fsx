open animals
open System.Threading
let repLen = 5
let env = environment(10, 10, repLen, 10, 7, 5, true)


printfn "\n\n\n////////////////////////////////////////////////////////
////////////CHECKING TICK FUNCTIONS/////////////////////
////////////////////////////////////////////////////////"

printfn "\n \n \n"
let mutable index = 0
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isNone(env.board.moose.[index].tick()))

env.board.moose.[index].reproduction <- 0
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isSome(env.board.moose.[index].tick()))

index <- 3
env.board.moose.[index].reproduction <- 0
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isSome(env.board.moose.[index].tick()))

index <- 5
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isNone(env.board.moose.[index].tick()))

printfn "\n \n"


index <- 0
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isNone(env.board.wolves.[index].tick()))

env.board.wolves.[index].reproduction <- 0
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isSome(env.board.wolves.[index].tick()))

index <- 7
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isNone(env.board.wolves.[index].tick()))

index <- 9
env.board.wolves.[index].reproduction <- 0
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isSome(env.board.wolves.[index].tick()))

printfn "\n \n \n"

printfn "////////////////////////////////////////////////////////
//////////////////////ENV FUNCTIONS/////////////////////
////////////////////////////////////////////////////////"


printfn "\n \n \n"
printfn "testing af genMoveVector, her har vi valgt bare at skrive den ud 10 gange da vi forudsætter at fsharps random er god nok."

let sleeptime = 20

printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())
Thread.Sleep(sleeptime);
printfn "testing af genMoveVector, result: %A" (env.genMoveVector())

printfn "\n \n \n"

index <- 0

printfn "testing af moveAnimal, is it as expected: %b" (Option.isSome (env.moveAnimal (env.board.wolves.[index].position)))

env.board.wolves.[index].position <- None
printfn "testing af moveAnimal, is it as expected: %b" (Option.isNone (env.moveAnimal (env.board.wolves.[index].position)))

index <- 3
env.board.wolves.[index].position <- None
printfn "testing af moveAnimal, is it as expected: %b" (Option.isNone (env.moveAnimal (env.board.wolves.[index].position)))

index <- 6
printfn "testing af moveAnimal, is it as expected: %b" (Option.isSome (env.moveAnimal (env.board.wolves.[index].position)))

printfn "\n \n \n"

let mutable expected = 10

printfn "testing af countMoose. there is: %i. is result as expected? %b" env.countMoose (expected = env.countMoose)


env.board.moose.[0].position <- None
env.board.moose.[3].position <- None
env.board.moose.[5].position <- None
expected <- 7
printfn "testing af countMoose. there is: %i. is result as expected? %b" env.countMoose (expected = env.countMoose)


expected <- 8
printfn "testing af countWolfs. there is: %i. is result as expected? %b " env.countWolfs (expected = env.countWolfs)

env.board.wolves.[5].position <- None
expected <- 7
printfn "testing af countWolfs. there is: %i. is result as expected? %b " env.countWolfs (expected = env.countWolfs)


printfn "\n \n \n"

let mutable pos = (0, 0)
let mutable expectedBool = true

printfn "testing af checkForAnimalsAtPosition, pos is %A. function gave %b. is this as expected? %b" pos (env.checkForAnimalsAtPosition (pos)) (expectedBool = env.checkForAnimalsAtPosition (pos))

expectedBool <- false
pos <- Option.get env.board.wolves.[4].position
printfn "testing af checkForAnimalsAtPosition, pos is %A. function gave %b. is this as expected? %b" pos (env.checkForAnimalsAtPosition (pos)) (expectedBool = env.checkForAnimalsAtPosition (pos))

expectedBool <- false
pos <- Option.get env.board.moose.[9].position
printfn "testing af checkForAnimalsAtPosition, pos is %A. function gave %b. is this as expected? %b" pos (env.checkForAnimalsAtPosition (pos)) (expectedBool = env.checkForAnimalsAtPosition (pos))

expectedBool <- true
pos <- (-100, -100)
printfn "testing af checkForAnimalsAtPosition, pos is %A. function gave %b. is this as expected? %b" pos (env.checkForAnimalsAtPosition (pos)) (expectedBool = env.checkForAnimalsAtPosition (pos))

printfn "\n \n \n"

env.board.wolves <- []
env.board.moose <- List.init 5 (fun i -> moose(repLen));

let mutable i = 0
for m in env.board.moose do
    m.position <- Some (i, 0)
    i <- i + 1

let mutable somePos = Some (0, 0)
expectedBool <- false
printfn "testing af checkValidMove. pos is %A. is this as expected? %b" somePos (expectedBool = (env.checkValidMove somePos))

somePos <- Some (0, 1)
expectedBool <- true
printfn "testing af checkValidMove. pos is %A. is this as expected? %b" somePos (expectedBool = (env.checkValidMove somePos))

somePos <- Some (1, 1)
expectedBool <- true
printfn "testing af checkValidMove. pos is %A. is this as expected? %b" somePos (expectedBool = (env.checkValidMove somePos))

somePos <- Some (3, 0)
expectedBool <- false
printfn "testing af checkValidMove. pos is %A. is this as expected? %b" somePos (expectedBool = (env.checkValidMove somePos))

somePos <- Some (4, 6)
expectedBool <- true
printfn "testing af checkValidMove. pos is %A. is this as expected? %b" somePos (expectedBool = (env.checkValidMove somePos))

somePos <- None
expectedBool <- true
printfn "testing af checkValidMove. pos is %A. is this as expected? %b" somePos (expectedBool = (env.checkValidMove somePos))


printfn "\n \n \n"

somePos <- Some (0,0)
expectedBool <- true
printfn "testing af findMooseAtPosition. is this as expected? %b" ((env.findMooseAtPosition somePos) = expectedBool)

somePos <- Some (0,1)
expectedBool <- false
printfn "testing af findMooseAtPosition. is this as expected? %b" ((env.findMooseAtPosition somePos) = expectedBool)

somePos <- Some (3,0)
expectedBool <- true
printfn "testing af findMooseAtPosition. is this as expected? %b" ((env.findMooseAtPosition somePos) = expectedBool)

somePos <- Some (7,5)
expectedBool <- false
printfn "testing af findMooseAtPosition. is this as expected? %b" ((env.findMooseAtPosition somePos) = expectedBool)

printfn "\n \n \n"

somePos <- Some (3,0)
expectedBool <- true
printfn "testing af checkFieldsAround. at pos %A. is this as expected? %b" somePos (expectedBool = (env.checkFieldsAround somePos))

somePos <- None
expectedBool <- false
printfn "testing af checkFieldsAround. at pos %A. is this as expected? %b" somePos (expectedBool = (env.checkFieldsAround somePos))
let newmoose1 = moose(repLen)
let newmoose2 = moose(repLen)

env.board.moose <- newmoose1::env.board.moose
env.board.moose <- newmoose2::env.board.moose

newmoose1.position <- Some (0, 1)
newmoose2.position <- Some (1, 1)

somePos <- Some (0, 0)
expectedBool <- false
printfn "testing af checkFieldsAround. at pos %A. is this as expected? %b" somePos (expectedBool = (env.checkFieldsAround somePos))

printfn "\n \n \n"

somePos <- Some (0,0)
expected <- 1
printfn "testing af CheckEating. at pos %A. this many found %i. is this as expected? %b" somePos (env.CheckEating somePos).Count (expected <= (env.CheckEating somePos).Count)

somePos <- Some (5,5)
expected <- 1
printfn "testing af CheckEating. at pos %A. this many found %i. is this as expected? %b" somePos (env.CheckEating somePos).Count (expected >= (env.CheckEating somePos).Count)

somePos <- Some (4,1)
expected <- 1
printfn "testing af CheckEating. at pos %A. this many found %i. is this as expected? %b" somePos (env.CheckEating somePos).Count (expected <= (env.CheckEating somePos).Count)

somePos <- Some (1,0)
expected <- 1
printfn "testing af CheckEating. at pos %A. this many found %i. is this as expected? %b" somePos (env.CheckEating somePos).Count (expected <= (env.CheckEating somePos).Count)


printfn "\n \n \n"

index <- 2
somePos <- Some (0,0)
let mutable expectedOption = None
env.KillMooseFromPosition somePos
printfn "testing af KillMooseFromPosition. at pos %A. moose pos %A. is this as expected? %b" somePos env.board.moose.[index].position (env.board.moose.[index].position = expectedOption)

index <- 4
somePos <- Some (2,0)
env.KillMooseFromPosition somePos
printfn "testing af KillMooseFromPosition. at pos %A. moose pos %A. is this as expected? %b" somePos env.board.moose.[index].position (env.board.moose.[index].position = expectedOption)

printfn "\n \n \n"

let newwolf1 = wolf(repLen, 10)
let newwolf2 = wolf(repLen, 10)

env.board.wolves <- newwolf1::env.board.wolves
env.board.wolves <- newwolf2::env.board.wolves

printfn "test af makeQueue. is this scrambled? %A" env.makeQueue
Thread.Sleep(sleeptime);
printfn "test af makeQueue. is this scrambled? %A" env.makeQueue
Thread.Sleep(sleeptime);
printfn "test af makeQueue. is this scrambled? %A" env.makeQueue

printfn "\n \n \n"

let expectedwolfPopulation = 1
let expectedMoosePopulation = 5

let mutable verbose = true

env.board.wolves.[0].position <- Some (1, 5)
env.board.wolves.[1].position <- None

newmoose1.position = None
newmoose2.position = None

env.removeDeadAnimals

if (expectedwolfPopulation <> env.board.wolves.Length) then
    verbose <- false

if (expectedMoosePopulation <> env.board.moose.Length) then
    verbose <- false

printfn "there are %i wolves and %i mooses is this as expected? %b" env.board.wolves.Length env.board.moose.Length verbose


