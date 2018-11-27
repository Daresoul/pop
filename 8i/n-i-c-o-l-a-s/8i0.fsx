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

let rec checkFigure (figure : figure) : bool =
    match figure with
    | Cirkel (( cx , cy ) , r , col ) ->
        if ( r < 0) then
            false
        
    
    | Rectangle (( x0 , y0 ) , (x1 , y1 ) , col ) ->

let width = 256
let height = 256
// Laver bitmap med størrelse 256 256

// 8i.0
let mix = figtest

// 8i.2
makePicture "figTest" mix 100 150
