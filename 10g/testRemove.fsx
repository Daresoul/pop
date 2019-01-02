let mutable newi = [0; 1; 2; 3; 4]
let removeAt index =

  //Laver en tuple af om boolean og int
  // booleanen bliver lavet ved at den er true hvis den er alt andet end indexet.
  let checkedList = List.mapi (fun i el -> (i <> index, el)) newi

  // tager den første tuple i alle elementerne i listen og tjekker om de er true, alt der ikke er true bliver smidt væk
  let filteredList = List.filter fst checkedList

  // laver listen af tupler om til den gamle liste uden det valgte index, det gør vi udfra snd tuplen af vores filterede liste.
  let newList = List.map snd filteredList
  
  newi <- newList
  //Laver en tuple af om boolean og int
  // booleanen bliver lavet ved at den er true hvis den er alt andet end indexet.

  //|> List.mapi (fun i el -> (i <> index, el))

  // tager den første tuple i alle elementerne i listen og tjekker om de er true, alt der ikke er true bliver smidt væk

  //|> List.filter fst

  // laver listen af tupler om til den gamle liste uden det valgte index, det gør vi udfra snd tuplen af vores filterede liste.

  //|> List.map snd



removeAt 2

printfn "%A" newi