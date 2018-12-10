

let bmp = ImgUtil .mk 100 120  //<-- lav et bmp som er 256 x 256 pixel stort

do ImgUtil . setSolidBox (ImgUtil . fromRgb(128 ,128 ,128)) (0,0) (99,119) bmp

do ImgUtil . setCircle (ImgUtil . red) 50 50 45 bmp

do ImgUtil . setSolidBox (ImgUtil . blue) (40,40) (90,110) bmp

do ImgUtil . toPngFile "  8i0 .png" bmp