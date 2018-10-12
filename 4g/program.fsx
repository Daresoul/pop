///This program prints a table showing what polyLen n returns if n is from 1 to 10
///<parameter>n</parameter>
///<return>length of megagon<return/>
let circlecurcomfrance : float = 7.
printfn "%15s %15s %15s %15s" "n" "polygon-value" "cirkel value" "diff"
for i = 0 to 25 do
    let circumfrance : float = vec2d.polyLen i (float 1)
    let diff : float = circlecurcomfrance - circumfrance
    printfn "%15i %15f %15f %15f" i circumfrance circlecurcomfrance diff

printfn "4g.2
b)
For a polygone with n-> infinity the length (i.e. circumference) goes towords that of a perfect circle with at circumfrence of pi x 2. This is because the polygon we are making have the length of 1, i.e the radius of the circle is 1. \n
If one were to looks at a megagon (polygon with a million sides.) it would for the human eye a perfect circle. If used to calculate the earth circumfrence it would only be  1/16 of a  millimeters off compared to a caclulation with 2*pi*r" 