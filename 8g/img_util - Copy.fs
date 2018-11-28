module ImgUtil

open System.Drawing
open System.Windows.Forms

type SmoothForm() as x =  // Thanks to Janro
    inherit Form()
    do x.DoubleBuffered <- true

// colors
type color = System.Drawing.Color
let red : color = Color.Red
let blue : color = Color.Blue
let green : color = Color.Green
let fromRgb (r:int,g:int,b:int) : color =
  Color.FromArgb(255,r,g,b)
let fromArgb (a:int,r:int,g:int,b:int) : color =
  Color.FromArgb(a,r,g,b)

let format = Imaging.PixelFormat.Format24bppRgb

// bitmaps
type bitmap = System.Drawing.Bitmap
let mk w h : bitmap = new Bitmap (w,h,format)
let setPixel (c: color) (x,y) (bmp:bitmap) : unit = bmp.SetPixel (x,y,c)
let setLine (c: color) (x1:int,y1:int) (x2:int,y2:int) (bmp:bitmap) : unit =
  let graphics = Graphics.FromImage(bmp)
  let pen = new Pen(c)
  in graphics.DrawLine(pen, x1, y1, x2, y2);

let setBox c (x1,y1) (x2,y2) bmp =
  do setLine c (x1,y1) (x2,y1) bmp
  do setLine c (x2,y1) (x2,y2) bmp
  do setLine c (x2,y2) (x1,y2) bmp
  do setLine c (x1,y2) (x1,y1) bmp

// read a bitmap file
let fromFile (fname : string) : bitmap =
  new Bitmap(fname)

// save a bitmap as a png file
let toPngFile (fname : string) (b: bitmap) : unit =
  b.Save(fname, Imaging.ImageFormat.Png) |> ignore

let bitmap_of (f:bitmap -> unit) (r:Rectangle) : bitmap =
  let bitmap = new Bitmap (r.Width, r.Height, format)
  do f bitmap
  bitmap

let redraw (g:Rectangle -> bitmap) (b:bitmap ref) (w: #Form) _ =
  do b := g w.ClientRectangle
  do w.Invalidate()

let paint (b:bitmap ref) (v: #Form) (e:PaintEventArgs) =
  let r = e.ClipRectangle
  e.Graphics.DrawImage(!b,r,r,GraphicsUnit.Pixel)

// show bitmap in a gui
let show (t: string) (bmp:bitmap) : unit =
  let h = bmp.Height
  let w = bmp.Width
  let form = new SmoothForm (Visible=true,Text=t,Height=h,Width=w)
  do form.Paint.Add(paint (ref bmp) form)
  do Application.Run form

type KeyEventArgs = System.Windows.Forms.KeyEventArgs

// start an app that can listen to key-events
let runApp (t:string) (w:int) (h:int)
           (f:int -> int -> 's -> bitmap)
           (onKeyDown: 's -> KeyEventArgs -> 's option) (s:'s) : unit =
  let form = new SmoothForm (Visible=true,Text=t,Width=w,Height=h)
  let state = ref s
  let g (r:Rectangle) : bitmap = f r.Width r.Height (!state)
  let bitmap = ref (f w h (!state))
  form.Resize.Add(redraw g bitmap form)
  form.Paint.Add(paint bitmap form)
  form.KeyDown.Add(fun e -> if e.KeyCode = Keys.Escape then form.Close()
                            else match onKeyDown (!state) e with
                                   | None -> ()
                                   | Some s -> (state := s; redraw g bitmap form ()))
  Application.Run form

let runSimpleApp t w h (f:bitmap->unit) : unit =
  runApp t w h (fun w h () ->
                  let bitmap = new Bitmap (w, h, format)
                  do f bitmap
                  bitmap)
               (fun _ _ -> None) ()

type point = int * int 
type colour = int * int * int 
type figure =
    | Circle of point * int * colour
    | Rectangle of point * point * colour
    | Mix of figure * figure


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

let makePicture (s: string)(f: figure)(b: int)(h: int) =
    let bmp = mk b h
    let bGC = (128,128,128)
    let mutable farve =(255,255,255)
    for i=0 to b-1 do   
        for j=0 to h-1 do 
            let pic = colourAt (i,j) f
            farve <- 
                match pic with
                |Some col -> col 
                |None -> bGC
            do setPixel (fromRgb farve) (i,j) bmp 
    do toPngFile (s+".png") bmp

//Small set of functions that returns first, second, or third part of a tuple.
let first (a, _, _) = a
let second (_, b, _) = b
let thirde (_, _, c) = c


let checkColour (c): bool = 
    ((first c)<=255 && (first c)>=0 && (second c)<=255 && (second c)>=0 && (thirde c)<=255 && (thirde c)>=0)

let rec checkFigure (f: figure) : bool = 
    match f with
    | Circle ((x,y) , r, colour)-> (((r>=0))&&(checkColour colour))
    | Rectangle ((x1,y1), (x2,y2), colour) -> ((x1<=x2)&&(y1<=y2)&&(checkColour colour))
    | Mix (fig1, fig2) -> checkFigure fig1 && checkFigure fig2

let moveCircle (x1,y1)(x,y)(r)(colour) = 
    let (newCenter : point) = (x1 + x , y1 + y)
    let (newCircle : figure) = Circle (newCenter, r, colour)
    newCircle

let moveRectangle (x1,y1)(x2,y2)(x,y)(colour)  =
    let (newSqrLeft : point) = ((x1 + x), (y1 + y))
    let (newSqrRight : point) =  ((x2 + x), (y2 + y))
    let (newSqr : figure) = Rectangle (newSqrLeft, newSqrRight, colour)
    newSqr

let rec move (f: figure)(x,y)  = 
    match f with
    | Circle ((x1,y1) , r, colour) -> moveCircle (x1,y1) (x,y) r colour
    | Rectangle ((x1,y1), (x2,y2), colour) -> moveRectangle (x1,y1) (x2,y2) (x,y) colour
    | Mix (fig1, fig2) -> Mix ((move fig1 (x,y)), (move fig2 (x,y))) 

let rec figureFind(f: figure) (l :point list) =
        match f with
        | Circle ((x1,y1) , r, colour) -> l @ [((x1-r),(y1-r))] @ [((x1+r),(y1+r))]
        | Rectangle ((x1,y1), (x2,y2), colour) -> l @ [(x1,y1)] @ [(x2,y2)]
        | Mix (fig1, fig2) -> l @ (figureFind fig1 l) @ (figureFind fig2 l)

let boundingBox (f: figure) : (point)*(point) = 
    let mutable l = []
    l <- figureFind f l
    let len = l.Length
    let mutable big = (0,0)
    let mutable small = (0,0)
    big <- l.[0]
    small <-l.[1] 
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