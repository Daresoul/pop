type Game() = class
    // Holds all game settings (like how many ticks and how many ticks per birth and so on)
end

type Board() = class
    // Holds all board information
    // like all the animals in 2 lists
end

type Animal() = class
    // the data of an animal all has
end

type Moose() = class
    inherit Animal()
    // the data only mooses has
end

type Wolf() = class
    inherit Animal()
    // The data only wolfs has
end