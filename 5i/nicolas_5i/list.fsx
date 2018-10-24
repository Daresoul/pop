// Opgave 5i.0 a
let list = [[1; 2; 3]; [4; 6]]
let list1 = [[2]; [6; 4]; [1]] // Exptected [2; 6; 4; 1]
let flist = [1.0; 2.0; 3.0; 4.0; 5.0]
printfn "full list: %A" list
printfn "Is valid: %b" (lists.isTable list)
printfn "First column: %A" (lists.firstColumn list)
printfn "Drop first column: %A" (lists.dropFirstColumn list)
printfn "Transpose: %A" (lists.transpose list)
printfn "concat: %A" (lists.concat list1)
printfn "gennemsnit: %A" (lists.gennemsnit flist)