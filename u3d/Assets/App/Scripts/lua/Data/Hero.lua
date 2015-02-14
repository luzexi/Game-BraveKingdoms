

local function init()
    --
end


local function create( tableid )
    HERO_GENERATE_INDEX = HERO_GENERATE_INDEX + 1
    local hero = {}
    hero.id = HERO_GENERATE_INDEX
    hero.tableid = tableid
    hero.level = 1
    hero.exp = 0
    hero.equip = 0
    return hero
end



local t = {}
t.create = create
t.init = init
return t

