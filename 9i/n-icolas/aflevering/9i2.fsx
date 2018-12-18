open System.Web.Configuration
open System.IO

/// <summary>This will remove many special charaters from a string</summary>
/// <param name="s">string you wanna remove alot of special chars from</param>
/// <returns>Returns string without special chars</returns>
let removeChars (s : string) : string =
    let stringWithoutDot = s.Replace (".", "")
    let stringWithoutComma = stringWithoutDot.Replace (",", "")
    let stringWithoutExclamationMark = stringWithoutComma.Replace ("!", "")
    let stringWithoutColon = stringWithoutExclamationMark.Replace (":", "")
    let stringWithoutQoute = stringWithoutColon.Replace("\"", "")
    let removedNewLinen = stringWithoutQoute.Replace("\\n", "")
    let removedNewLiner = removedNewLinen.Replace("\\r", "")
    let removedNewLinenr = removedNewLiner.Replace("\\n\\r", "")
    let removedNewLinern = removedNewLinenr.Replace("\\r\\n", "")
    let lowercaseString = removedNewLinern.ToLower()
    lowercaseString
    
/// <summary>Creates a sequence of all words and sort it by how many times it has apeared</summary>
/// <param name="s">the string you wanna get a sorted sequence of</param>
/// <returns>Returns a sorted sequence of all words</returns>
let createWordSequence (s : string) =
    s.Split([|' '|])
    |> Seq.countBy (fun s -> s)
    |> Seq.sortByDescending snd

/// <summary>gets string from storeClausLilleClaus.txt file</summary>
/// <returns>Returns the text from a file called storeClausLilleClaus.txt</returns>
/// <exception>Thrown when the file dosent exist</exception>
let readFromFile : string =
    try
        if ( File.Exists ("storeClausLilleClaus.txt")) then
            let allLinesArray = File.ReadAllLines "storeClausLilleClaus.txt"
            allLinesArray
            |> String.concat ", "
        else
            failwith "No file named storeClausLilleClaus.txt found"
    with
    | Failure (msg) -> printfn "%s" msg;""

/// <summary>Creates a string from all the words with its occourence</summary>
/// <param name="freq">the sequence we want to write out</param>
/// <returns>long string with all the data inside</returns>
let createFrequenctString (freq : seq<string * int>) =
    freq
    |> Seq.fold (fun acc item -> acc + (sprintf "The word %20s has %20i repetitions in the story\r\n" (fst item) (snd item)) ) ""

/// <summary>Writes a string to a filem, with the name hyppighed</summary>
/// <param name="str">the string you want to insert into the file</param>
let writeToFile (str : string) =
    let basePath = __SOURCE_DIRECTORY__
    File.WriteAllText(sprintf "%s\\hyppighed.txt" basePath, str)  



let str = readFromFile
let currentstring = removeChars str
let newseq = createWordSequence currentstring

let writeString = createFrequenctString newseq

writeToFile (writeString)
