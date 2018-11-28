///<summary> A generic function findes all the coordinate values associated with figures (circle, Rectangle, or mix). </summary>
///<param figure = f> The figure to calculate upon. </param>
///<param list = l> Needs a starting list to function. </param>
///<returns> A list with all coordinats found for the given figure. </returns>
let rec figureFind(f: ImgUtil . figure) (l :ImgUtil . point list) =
        match f with
        | ImgUtil . Circle ((x1,y1) , r, colour) -> l @ [((x1-r),(y1-r))] @ [((x1+r),(y1+r))]
        | ImgUtil . Rectangle ((x1,y1), (x2,y2), colour) -> l @ [(x1,y1)] @ [(x2,y2)]
        | ImgUtil . Mix (fig1, fig2) -> l @ (figureFind fig1 l) @ (figureFind fig2 l)

///<summary> A generic function that calcualtes what size a box would have to have to fit a figure (circle, Rectangle, or mix) in side of it. </summary>
///<param figure = f> The figure be boxed. </param>
///<returns> A set of coordinats that are the upper right corner tubled with the lower left corner of the box. </returns>
let boundingBox (f: ImgUtil . figure) : (ImgUtil . point)*(ImgUtil . point) = 
    let mutable l = []
    l <- figureFind f l
    let len = l.Length
    let mutable big = (0,0)
    let mutable small = (0,0)
    big <- l.[0]
    small <-l.[1] 
    printfn "%A" l
    for i = 0 to (len-1) do 
        if ((fst l.[i]) > ( fst big)) then
            big <-((fst l.[i]), (snd big))
        else big <- big
        if ((snd l.[i]) > (snd big)) then
            big <-(( fst big), (snd l.[i]))
        else big <- big
        if ((fst l.[i]) < ( fst small)) then
            small <-((fst l.[i]), (snd small))
        else small <- small
        if ((snd l.[i]) < (snd small)) then
            small <-(( fst small), (snd l.[i]))
        else small <- small
    (small,big)


//ALT OVERSTÅENDE ER FLYTTET TIL img_util.fs OG TILPASSET (i.e. alle "ImgUtil . " er blevet fjernet.)

//Whiteboxtesting to the max.
let (CircleCenter : ImgUtil . point) = (50,50)
let (radius : int) = (45)
let (red : ImgUtil . colour) = (255,0,0)
let (figCircle : ImgUtil . figure) = ImgUtil . Circle (CircleCenter, radius, red)

let (sqrLeft : ImgUtil . point) = (40,40)
let (sqrRight : ImgUtil . point) = (90,110)
let (blue : ImgUtil . colour) = (0,0,255)
let (figSqr : ImgUtil . figure) = ImgUtil . Rectangle (sqrLeft, sqrRight, blue)

let (figTest : ImgUtil . figure) = ImgUtil . Mix (figCircle, figSqr)
let (otherTest: ImgUtil . figure) = ImgUtil . move figTest (-20,20)

printf "cir cle box %A\n" (boundingBox figCircle)
printf "sqr box %A\n" (boundingBox figSqr)
printf "mix box %A\n" (boundingBox figTest)
printf "other mix box %A\n" (boundingBox otherTest)
