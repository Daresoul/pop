open System
open System.Net
open System.Text.RegularExpressions

let (|Regex|_|) (pattern : string) (input : string) =
        let m = Regex.Match(input, pattern)
        if m.Success then
                printfn "seq %A" m.Groups
                printfn "seq seq seq: %A" (List.tail [ for g in m.Groups -> g.Value ])
                Some (List.tail [ for g in m.Groups -> g.Value ]) //List.fold (fun acc (x) -> acc + x) 0
        else
                None

let getInput (url : string) : string = 
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    let html = reader.ReadToEnd() 
    printfn "finished downloading %s" url
    html

let countLinks (url : string) : int =
        let html = getInput url
        let pattern = """\<a"""

        if (Regex(pattern).IsMatch(html)) then
                let m = Regex(pattern).Matches(html)
                printfn "this many found: %i \n\n" m.Count
                m.Count
        else
                printfn "none found\n\n"
                0

// a list of sites to fetch
let sites = ["https://www.w3schools.com/html/html_links.asp"; "https://www.google.com"; "http://tsponline.dk/pop/links/1.htm"; "http://tsponline.dk/pop/links/5.htm"; "http://tsponline.dk/pop/links/8.htm"; "http://tsponline.dk/pop/links/20.htm"; "http://tsponline.dk/pop/links/1000.htm"]

let startTime = DateTime.Now
sites                     // start with the list of sites
|> List.map countLinks      // loop through each site and download
printfn "%A msec" (DateTime.Now - startTime)