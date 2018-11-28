type point = int * int 
type colour = int * int * int 
type figure =
    | Circle of point * int * colour
    | Rectangle of point * point * colour
    | Mix of figure * figure

let (CircleCenter : point) = (50,50)
let (radius : int) = (45)
let (red : colour) = (255,0,0)

let (sqrLeft : point) = (40,40)
let (sqrRight : point) = (90,110)
let (blue : colour) = (0,0,255)

let (figCircle : figure) = Circle (CircleCenter, radius, red)
let (figSqr : figure) = Rectangle (sqrLeft, sqrRight, blue)
let (figTest : figure) = Mix (figCircle, figSqr)


//Not quite sure what im to comment on this part...