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

(**********************************************************************************************************
************************************************ 8i.0 *****************************************************
***********************************************************************************************************)

// 8i.0 funktionen
/// <summary>Creates a mix figure between a circle and a rectangle with given sizes</summary>
/// <returns>Returns a mix variable</returns>
/// <remarks>Denne funktion virker med 8i.0 opgaven</remarks>
let figtest : figure =
    let circle = Circle ((50, 50), 45, (255, 0, 0))
    let Rectangle = Rectangle ((40, 40), (90, 110), (0, 0, 255))
    let mix = Mix (circle, Rectangle)
    mix

(**********************************************************************************************************
************************************************ 8i.1 *****************************************************
***********************************************************************************************************)

/// <summary>This creates a picure from a figure by creating a canvas with a width and heigh</summary>
/// <param name="filename">The name of the file to create</param>
/// <param name="figure">En type figur</param>
/// <param name="w">The width of the image</param>
/// <param name="h">The height of the image</param>
/// <returns>Creates an image file</returns>
/// <remarks>Denne funktion er lavet for 8i.1</remarks>
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

(**********************************************************************************************************
************************************************ 8i.3 *****************************************************
***********************************************************************************************************)

/// <summary>gets the first value of a 3 valued tuple</summary>
/// <param name="a">The first value of the tuple</param>
/// <param name="b">The second value of the tuple</param>
/// <param name="c">The third value of the tuple</param>
/// <returns>returns the first value of a tuple</returns>
let getFirstTupleValue (a, b, c) : int =
    a

/// <summary>gets the second value of a 3 valued tuple</summary>
/// <param name="a">The first value of the tuple</param>
/// <param name="b">The second value of the tuple</param>
/// <param name="c">The third value of the tuple</param>
/// <returns>returns the second value of a tuple</returns>
let getSecondTupleValue (a, b, c) : int =
    b

/// <summary>gets the third value of a 3 valued tuple</summary>
/// <param name="a">The first value of the tuple</param>
/// <param name="b">The second value of the tuple</param>
/// <param name="c">The third value of the tuple</param>
/// <returns>returns the third  value of a tuple</returns>
let getThirdTupleValue (a, b, c) : int =
    c

/// <summary>checks wether a color is valid or not</summary>
/// <param name="col">The color tuple</param>
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



/// <summary>Checks wether a figure in its values</summary>
/// <param name="figure">The figure you wanna check is good</param>
/// <returns>Returns true if the figure is made correctly</returns>
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

(**********************************************************************************************************
************************************************ 8i.4 *****************************************************
***********************************************************************************************************)

/// <summary>Moves a figure by an vector</summary>
/// <param name="figure">The figure you want to move</param>
/// <param name="a,b">The vector you want to move it by</param>
/// <returns>Returns the moved figure</returns>
let rec move (figure : figure) ((a,b) : int * int) : figure =
    match figure with
    | Circle ((cx, cy), r, col) ->
        Circle ( ((cx + a), (cx + b)), r, col )
    | Rectangle ((x0, y0), (x1, y1), col) ->
        Rectangle ( ((x0 + a), (y0 + b)), ( (x1 + a), (y1 + b) ), col)
    | Mix (f1, f2) ->
        Mix ( ( move (f1) (a, b) ), (move (f2) (a,b) ) )

(**********************************************************************************************************
************************************************ 8i.5 *****************************************************
***********************************************************************************************************)

/// <summary>This creates coordinates for rectangle with the figure inside</summary>
/// <param name="figure">The figure you want to bind the boundries of</param>
/// <param name="lstx">List of all x values (start empty)</param>
/// <param name="lsty">List of all y values (start empty)</param>
/// <returns>returns 2 lists with all x coordinates and all y coordinates</returns>
let rec findBoundries (figure : figure) (lstx : int list) (lsty : int list) : int list * int list =
    match figure with
    | Circle ((cx, cy), r, col) ->
        let minx = cx - r
        let maxx = cx + r

        let miny = cy - r
        let maxy = cy + r

        let newx = minx :: lstx
        let newxx = maxx :: newx

        let newy = miny :: lsty
        let newyy = maxy :: newy

        (newxx, newyy)
    
    | Rectangle ((x0, y0), (x1, y1), col) ->
        let newx = x0 :: lstx
        let newxx = x1 :: newx

        let newy = y0 :: lsty
        let newyy = y1 :: newy

        (newxx, newyy)
    
    | Mix (f1, f2) ->
        let fig1 = findBoundries f1 lstx lsty
        let fig2 = findBoundries f2 lstx lsty
        ((fst fig1 @ fst fig2), (snd fig1 @ snd fig2))


/// <summary>creates the bounding box with the 2 corners returned</summary>
/// <param name="figure">Figure you want to bind the boundry of</param>
/// <returns>returns 2 coordinates of the rectangle</returns>
let boundingBox (figure : figure) : point * point =
    let (x,y) = findBoundries figure [] []

    let xmax = List.max x
    let xmin = List.min x

    let ymax = List.max y
    let ymin = List.min y

    ((xmin,ymin), (xmax,ymax))


let width = 256
let height = 256

(**********************************************************************************************************
************************************************ 8i.0 *****************************************************
***********************************************************************************************************)
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

(**********************************************************************************************************
************************************************ 8i.2 *****************************************************
***********************************************************************************************************)
makePicture "figTest" mix 100 150

(**********************************************************************************************************
************************************************ 8i.4 *****************************************************
***********************************************************************************************************)
makePicture "moveTest" (move figtest (-20, 20)) 100 150

(**********************************************************************************************************
************************************************ 8i.5 *****************************************************
***********************************************************************************************************)

let ((a,b), (c, d)) = boundingBox figtest//(Rectangle ((5, 5), (10, 10), (0,0,0)))
let rect = Rectangle ((a,b), (c,d), (0,0,0))
let newmix = Mix (rect, mix)

makePicture "boudningtest" newmix 100 150