open System.Drawing
type point = int * int // a point (x, y) in the plane
type colour = int * int * int // (red , green , blue ), 0..255
type figure =
| Circle of point * int * colour
// defined by center , radius , and colour
| Rectangle of point * point * colour
// defined by corners bottom -left , top -right , and colour
| Mix of figure * figure
// combine figures with mixed colour at overlap


// finds colour of figure at point
let rec colourAt ((x, y) : int * int) (figure : figure) : colour option =
    match figure with
    | Circle (( cx , cy ) , r , col ) ->
        if (x - cx ) * ( x - cx ) + (y - cy ) * (y - cy ) <= r * r
        // uses Pythagoras ' equation to determine
        // distance to center
        then Some col
        else None

    | Rectangle (( x0 , y0 ) , (x1 , y1 ) , col ) ->
        if x0 <= x && x <= x1 && y0 <= y && y <= y1
        // within corners
        then Some col
        else None
    
    | Mix (f1 , f2 ) ->
    match ( colourAt (x , y) f1 , colourAt (x ,y ) f2 ) with
    | ( None , c) -> c // no overlap
    | (c , None ) -> c // no overlap
    | ( Some (r1 ,g1 , b1 ) , Some (r2 ,g2 , b2 ) ) ->
        // average color
        Some (( r1 + r2 ) /2 , ( g1 + g2 ) /2 , ( b1 + b2 ) /2)

// 8i.0 funktionen
let figtest : figure =
    let circle = Circle ((50, 50), 45, (255, 0, 0))
    let Rectangle = Rectangle ((40, 40), (90, 110), (0, 0, 255))
    let mix = Mix (circle, Rectangle)
    mix

// 8i.1
let makePicture (filename : string) (figure : figure) (w : int) (h : int) =
    let bmp = ImgUtil.mk w h

    for i in 0 .. (w - 1) do
        for j in 0 .. (h - 1) do
            match colourAt (i,j) figure with
            |Some (x) -> 
                ImgUtil.setPixel ( ImgUtil.fromRgb (x) ) (i, j) bmp
            
            |None ->
                let grayColor = (128, 128, 128)
                ImgUtil.setPixel ( ImgUtil.fromRgb grayColor ) (i, j) bmp

    let completeFilename = sprintf "%s.png" filename
    do ImgUtil.toPngFile completeFilename bmp


let getFirstTupleValue (a, b, c) : int =
    a

let getSecondTupleValue (a, b, c) : int =
    b

let getThirdTupleValue (a, b, c) : int =
    c

///<summary>
/// This function will check if color values are all right
/// </summary>
/// <return>Will return true if all right otherwise return false</return>
let checkColor (col : int * int * int) : bool =
    let r = getFirstTupleValue col
    let g = getSecondTupleValue col
    let b = getThirdTupleValue col
    if r > 0 && r < 256 then
        true
    elif g > 0 && g < 256 then
        true
    elif b > 0 && b < 256 then
        true
    else
        false

let rec checkFigure (figure : figure) : bool =
    match figure with
    | Circle (( cx , cy ) , r , col ) ->
        if ( r <= 0) then
            false
        elif (cx < 0) || (cy < 0) then
            false
        elif not (checkColor col) then
            false
        else
            true
    
    | Rectangle (( x0 , y0 ) , (x1 , y1 ) , col ) ->
        if (x0 < 0) || y0 < 0 || x1 < 0 || y1 < 0 then
            false
        elif x1 < x0 || y1 < y0 then
            false
        elif not (checkColor col) then
            false
        else
            true
    
    | Mix (f1, f2) ->
        match (checkFigure f1, checkFigure f2) with
        | (true, true) -> true
        | _ -> false



let rec move (figure : figure) ((a,b) : int * int) : figure =
    match figure with
    | Circle ((cx, cy), r, col) ->
        Circle ( ((cx + a), (cx + b)), r, col )
    | Rectangle ((x0, y0), (x1, y1), col) ->
        Rectangle ( ((x0 + a), (y0 + b)), ( (x1 + a), (y1 + b) ), col)
    | Mix (f1, f2) ->
        Mix ( ( move (f1) (a, b) ), (move (f2) (a,b) ) )

let rec findUpperBoundry (figure : figure) : point * point =
    match figure with
    | Circle ((cx, cy), r, col) ->
    // ( (top boundry, bottom boundry), (left boundry, right boundry))
        ((cy - r, cy + r), (cx - r, cx + r))
    
    | Rectangle ((x0, y0), (x1, y1), col) ->
        ((y0, y1), (x0, x1))
    
    | Mix (f1, f2) ->
        let f1b = findUpperBoundry f1
        let f2b = findUpperBoundry f2
        
        let mutable upperBoundry : int = 0
        let mutable lowerBoundry : int = 0
        let mutable leftBoundry : int = 0
        let mutable rightBoundry : int = 0

        if(fst (fst f1b) > fst (fst f2b)) then
            upperBoundry <- fst (fst f1b)
        else
            upperBoundry <- fst (fst f2b)
        
        if (fst (snd f1b) > fst (snd f2b)) then
            lowerBoundry <- fst (snd f1b)
        else
            lowerBoundry <- fst (snd f2b)

        if (snd (fst f1b) > snd (fst f2b)) then
            leftBoundry <- snd (fst f1b)
        else
            leftBoundry <- snd (fst f2b)

        if (snd (snd f1b) > snd (snd f2b)) then
            rightBoundry <- snd (snd f1b)
        else
            rightBoundry <- snd (snd f1b)
        

        ((upperBoundry, lowerBoundry), (leftBoundry,rightBoundry))



let boundingBox (figure : figure) : point * point =
    let ((a,b), (c, d)) = findUpperBoundry figure
    
    let res = ((c, a), (d, b))
    printfn "result: %A" res
    res 

let width = 256
let height = 256
// Laver bitmap med størrelse 256 256

// 8i.0
let mix = figtest

(*

SHORT TEST OF THIS WORKING

printfn "mix should be working: %b" (checkFigure mix)
printfn "circle should be working: %b" (checkFigure (Circle ((50, 50), 45, (255, 0, 0))))
printfn "circle should not be working: %b" (checkFigure (Circle ((50, 50), 0, (255, 0, 0))))
printfn "circle should not be working: %b" (checkFigure (Circle ((50, 50), 45, (256, 0, 0))))

printfn "rect should be working: %b" (checkFigure (  Rectangle ((40, 40), (90, 110), (0, 0, 255))  ))
printfn "rect should not be working: %b" (checkFigure (  Rectangle ((40, 40), (90, 110), (0, 0, 257))  ))
printfn "rect should not be working: %b" (checkFigure (  Rectangle ((90, 110), (40, 40), (0, 0, 255))  ))

*)

// 8i.2
makePicture "figTest" mix 100 150

makePicture "moveTest" (move figtest (-20, 20)) 100 150

let ((a,b), (c, d)) = boundingBox figtest//(Rectangle ((5, 5), (10, 10), (0,0,0)))
let rect = Rectangle ((a,b), (c,d), (0,0,0))
let newmix = Mix (rect, mix)

makePicture "boudningtest" newmix 100 150