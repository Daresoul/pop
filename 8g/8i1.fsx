///<summary> A series of types that are used to generate figures that can be translated to the bmp format</summary>
///<param point=(x,y)> Set a point for a 2D coordinate system</param>
///<param colour=(r,g,b)> Set colour based on the red,green,blue system with their value between 0-255</param>
///<param figure> A type that contain three different types of figures, circle, rectangle or a mix of the two.</param>
type point = int * int 
type colour = int * int * int 
type figure =
    | Circle of point * int * colour
    | Rectangle of point * point * colour
    | Mix of figure * figure

///<summary> A function that colours at a specific coordinate, with colours being transparent in relation to the rgb value all ready at the location. </summary>
///<param coordinate = (x,y)> The specific  coordinate to be coloured.</param>
///<param figure> The figure that have to be colured in.</param>
///<returns>Returns a figure coloured as requested. </returns>
let rec colourAt (x,y) figure =
    match figure with
    | Circle ((cx ,cy), r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r
        then Some col else None
    | Rectangle ((x0 ,y0), (x1 ,y1), col) ->
        if x0 <=x && x <= x1 && y0 <= y && y <= y1
        then Some col else None
    | Mix (f1 , f2) ->
        match ( colourAt (x,y) f1 , colourAt (x,y) f2) with
        | (None , c) -> c 
        | (c, None ) -> c 
        | ( Some (r1 ,g1 ,b1), Some (r2 ,g2 ,b2)) ->Some (( r1+r2)/2, (g1+g2)/2, (b1+b2)/2)

///<summary> A function takes a figure and returns a .png file. </summary>
///<param s = string> The name of the .png file to be created.</param>
///<param f = figure> The figure that will be drawn.</param>
///<param b = int> The width in pixel of the .png file.</param>
///<param h = int> The weight in pixel of the .png file.</param>
///<returns>Returns a s.png file. </returns>
let makePicture (s: string)(f: figure)(b: int)(h: int) =
    let bmp = ImgUtil . mk b h
    let bGC = (128,128,128)
    let mutable farve =(255,255,255)
    for i=0 to b-1 do   
        for j=0 to h-1 do 
            let pic = colourAt (i,j) f
            farve <- 
                match pic with
                |Some col -> col 
                |None -> bGC
            do ImgUtil . setPixel (ImgUtil . fromRgb farve) (i,j) bmp 
    do ImgUtil . toPngFile (s+".png") bmp

//ALT OVERSTÅENDE ER FLYTTET TIL img_util.fs OG TILPASSET (i.e. alle "ImgUtil . " er blevet fjernet.)