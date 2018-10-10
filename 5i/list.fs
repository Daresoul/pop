module lists

let isTable (thislist : 'a list list) =
    // Boolean to check if lists are all the same len
    let mutable tableisTrue = true

    // if list is empty just make false
    if thislist.IsEmpty then
        tableisTrue <- false
    else
        // Gets length of the first element
        let fistList = thislist.Head.Length

        // For each list in thislist
        for innerlist in thislist do
            // Checker om længden er det samme som den første
            if innerlist.Length <> fistList then
                // sætter check til at være false
                tableisTrue <- false

    tableisTrue



let firstColumn (thislist : 'a list list) : 'a list =
    // the list to return
    let mutable newlist : 'a list = []

    if (isTable thislist) then
        // For each list in the list
        for innerlist in (List.rev thislist) do
            // Get first element of the list that is inside the list
            let thisitem = innerlist.Head
            let appendList : 'a list = [thisitem]

            // Adding first element of the inner list to the list we will return
            newlist <- thisitem::newlist
    newlist

let dropFirstColumn (thislist : 'a list list) : 'a list list =
    // Creates a new list
    let mutable newlist : 'a list list = []

    // If all talbes are the same length
    if (isTable thislist) then
        // go thought all elements in thislist
        for innerlist in (List.rev thislist) do
            // Get all elements besides the first
            let innerlistWithoutFirstColumn = innerlist.Tail

            // sætter elementet ind i en ny liste
            newlist <- innerlistWithoutFirstColumn::newlist
    
    // Returner en ny liste uden det første element i hvert element
    newlist

let transpose (thislist : 'a list list) : 'a list list =

    let mutable thisnewlist : 'a list list = thislist
    let mutable newlist : 'a list list = []

    // Checks alle elements is the same length
    if isTable thislist then
        // For each inner element
        for innerlist in thislist.Head do
            let firstcolumnn = (firstColumn thisnewlist)
            let firstcolumnRemovedList = (dropFirstColumn thisnewlist)
            thisnewlist <- firstcolumnRemovedList
            newlist <- firstcolumnn::newlist

    (List.rev newlist)

let concat (lst : 'a list list) =
    let newlst = lst |> List.collect (fun x -> x)
    newlst

let gennemsnit (lst : float list) =
    // Sums all numbers in the list
    let thisgennemsnit = Some (List.fold (fun newsum (x) -> ( x + newsum)) 0.0 lst / float lst.Length)

    // Returns the median
    thisgennemsnit