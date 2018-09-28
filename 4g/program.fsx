let circlecurcomfrance : float = 6.283185
printfn "%15s %15s %15s %15s" "n" "polygon-value" "cirkel value" "diff"
for i = 0 to 3600 do
    let circumfrance : decimal = vec2d.polyLenDecimal i (float 1)
    let diff : decimal = circlecurcomfrance - circumfrance
    printfn "%15i %15f %15f %15f" i circumfrance circlecurcomfrance diff