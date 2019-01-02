open animals
open System.Threading
let repLen = 5
let env = environment(10, 10, repLen, 10, 7, 5, true)


printfn "////////////////////////////////////////////////////////\n
         ////////////CHECKING TICK FUNCTIONS/////////////////////\n
         ////////////////////////////////////////////////////////\n"
let mutable index = 0
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isNone(env.board.moose.[index].tick()))

env.board.moose.[index].reproduction <- 0
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isSome(env.board.moose.[index].tick()))

index <- 3
env.board.moose.[index].reproduction <- 0
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isSome(env.board.moose.[index].tick()))

index <- 5
printfn "checking moose tick function index %i, rep value is %i. is it as expected? %b" index (env.board.moose.[index].reproduction) (Option.isNone(env.board.moose.[index].tick()))


index <- 0
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isNone(env.board.wolves.[index].tick()))

env.board.wolves.[index].reproduction <- 0
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isSome(env.board.wolves.[index].tick()))

index <- 7
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isNone(env.board.wolves.[index].tick()))

index <- 9
env.board.wolves.[index].reproduction <- 0
printfn "checking wolf tick function index %i, rep value is %i. is it as expected? %b" index (env.board.wolves.[index].reproduction) (Option.isSome(env.board.wolves.[index].tick()))

printfn "////////////////////////////////////////////////////////
//////////////////////ENV FUNCTIONS/////////////////////
////////////////////////////////////////////////////////"

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

printfn "testing af checkValidMove."