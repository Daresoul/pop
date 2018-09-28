let circlecurcomfrance : float = 7.
printfn "%15s %15s %15s %15s" "n" "polygon-value" "cirkel value" "diff"
for i = 0 to 3600 do
    let circumfrance : float = vec2d.polyLen i (float 1)
    let diff : float = circlecurcomfrance - circumfrance
    printfn "%15i %15f %15f %15f" i circumfrance circlecurcomfrance diff

