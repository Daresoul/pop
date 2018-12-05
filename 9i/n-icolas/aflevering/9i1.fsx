open System
open System.Net
open System.Text.RegularExpressions

/// <summary>This will get html code from an website url</summary>
/// <param name="url">The url of the site you want to download</param>
///<returns>Returns the html code as an string</returns>
let getInput (url : string) : string = 
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    let html = reader.ReadToEnd() 
    printfn "finished downloading %s" url
    html

/// <summary>Tests the sites agains a regex to find links on the site</summary>
/// <param name="url">The url of the site you want to download</param>
///<returns>returns amount of links on the site</returns>
let countLinks (url : string) : int =
        let html = getInput url
        let pattern = """\<a"""

        if (Regex(pattern).IsMatch(html)) then
                let m = Regex(pattern).Matches(html)
                m.Count
        else
                0

// a list of sites to fetch
let sites = ["https://www.w3schools.com/html/html_links.asp"; "https://www.google.com"; "http://tsponline.dk/pop/links/1.htm"; "http://tsponline.dk/pop/links/5.htm"; "http://tsponline.dk/pop/links/8.htm"; "http://tsponline.dk/pop/links/20.htm"; "http://tsponline.dk/pop/links/1000.htm"]

let startTime = DateTime.Now
sites                     // start with the list of sites
|> List.map countLinks      // loop through each site and download
printfn "%A msec" (DateTime.Now - startTime)

(*
    Begrundelse af valg

    Jeg valgte at bruge et kort regex udtryk da det ikke blev alt for compliceret da vi bare skal lede efter et <a tag med en sti til. Det gjorde at jeg hurtigt kunne lede hele sider igennem for at kunne finde
    hvor mange links der skulle være på et site selvom det er rimeligt stort.

*)