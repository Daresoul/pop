

let bmp = ImgUtil .mk 256 256  //<-- lav et bmp som er 256 x 256 pixel stort


//Laver en streg et pixel af gangen fra venstre øverste hjørne (0;0) til højre nedre hjørne (255;255)
for i=0 to 255 do 
    do ImgUtil . setPixel ( ImgUtil . fromRgb (255 ,255 ,255) ) (i ,i) bmp

//Laver en streg fra øverste højre hjørne (0;255) til nederste venstere hjørne (255;0)
do ImgUtil . setLine (ImgUtil . fromRgb (255,255,255)) (0,255) (255,0) bmp

//Laver en vinkelret firkant mellem (50;50) og (205;205)
do ImgUtil . setBox (ImgUtil . fromRgb (255,255,255)) (50,50) (205,205) bmp

//circle coordinate equation (x – h)^2 + (y – k)^2 = r2 where h and k are the center. Man burde kunen lave en funktion som ser om afstanden dist1 til (h;k) =< afstanden dist2 som er afstanden fra centrum. (Vi kunne i princis lave bounding box her, men lad os gemme det til senere)


//Konventer bmp til en png fil. 
do ImgUtil . toPngFile " test .png" bmp