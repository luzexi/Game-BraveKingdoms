


local function initdata()
    Battle = {}
    Battle.gold = 23888
    Battle.soul = 83344
    Battle.crystal = 3433
    Battle.catch_heros = {}
    Battle.heros = {}
    Battle.enemys = {}

    local lua_hero = require("Data/Hero")
    local tmphero = lua_hero.create(234)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)
    tmphero = lua_hero.create(23)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)

    local i = 0
    for i = 1 , #Player.heros , 1 do
        local battlehero = lua_hero.createBattleHero(Player.heros[i])
        table.insert(Battle.heros , #Battle.heros + 1 , battlehero)
    end
end





local t = {}
t.initdata = initdata
return t
