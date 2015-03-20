

local function init()
    --
end


local function create( tableid )
    HERO_GENERATE_INDEX = HERO_GENERATE_INDEX + 1
    local hero = {}
    hero.id = HERO_GENERATE_INDEX
    hero.tableid = tableid
    hero.lv = 1
    hero.exp = 23
    hero.equip = 0
    hero.attack = 11
    hero.defence = 14
    hero.maxhp = 144
    hero.recover = 3
    hero.lock = false
    return hero
end

local function createBattleHero( hero )
    local battlehero = {}
    battlehero.tableid = hero.tableid
    battlehero.equip = hero.equip
    battlehero.attack = hero.attack
    battlehero.defence = hero.defence
    battlehero.recover = hero.recover
    battlehero.hp = hero.maxhp
    battlehero.maxhp = hero.maxhp
    battlehero.sp = 0
    battlehero.maxsp = 100
    
    return battlehero
end



local t = {}
t.create = create
t.init = init
t.createBattleHero = createBattleHero
return t

