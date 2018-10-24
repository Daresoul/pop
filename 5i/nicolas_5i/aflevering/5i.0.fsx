// Funktioner kan blive fundet i list.fs og dokumentation i list.fsi
let list = [[1; 2; 3]; [4; 6; 5]]

printfn "full list: %A" list
printfn "Is valid: %b" (lists.isTable list)
printfn "First column: %A" (lists.firstColumn list)
printfn "Drop first column: %A" (lists.dropFirstColumn list)
printfn "Transpose: %A" (lists.transpose list)