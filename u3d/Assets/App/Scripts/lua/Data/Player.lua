
local hero = require "Data/Hero"



local function init()
    Player = {}
    Player.Name = "Jesse"
    Player.level = 1
    Player.exp = 0
    Player.gold =9999
    Player.soul = 9898
    Player.crystal = 341
    Player.farm = 3233
    Player.items = {}
    Player.heros = {}
    Player.groups = {}
    Player.mails = {}

    local tmpHero = hero.create(1)
    table.insert( Player.heros ,#Player.heros, tmpHero )
    tmpHero = hero.create(2)
    table.insert( Player.heros ,#Player.heros , tmpHero)
    tmpHero = hero.create(3)
    table.insert( Player.heros ,#Player.heros , tmpHero)
    tmpHero = hero.create(4)
    table.insert( Player.heros ,#Player.heros , tmpHero)
    tmpHero = hero.create(5)
    table.insert( Player.heros ,#Player.heros , tmpHero)
end



local t = {}
t.init = init
return t