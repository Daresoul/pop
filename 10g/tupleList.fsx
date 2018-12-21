member this.makeQueue() =
    let mutable queue = []
    
    let mutable End = _board.wolf.Length-1
    for i=0 to End do
      queue <- ("w", i) :: queue
    
    End <- _board.moose.Length-1
    for i=0 to End do
      queue <- ("m", i) :: queue
    
    let mutable r = []

    End <- queue.Length-1
    for i=0 to End do
        let j = any.Next(0, queue.Length)
        r <- queue.[j] :: r
        queue <- List.filter (fun x -> not(x=queue.[j])) queue
    r