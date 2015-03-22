
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3


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

    local res = HeroTable[""..hero.tableid].Model
    res = string.sub(res,7,#res)
    battlehero.object = GameObject.Instantiate(Resources.Load("Model/"..res))
    return battlehero
end

local function createBattleEnemy( hero )
    local battlehero = {}
    battlehero.tableid = hero.HeroID
    battlehero.equip = 0
    battlehero.attack = hero.Attack
    battlehero.defence = hero.Defence
    battlehero.recover = 0
    battlehero.hp = hero.HP
    battlehero.maxhp = hero.HP
    battlehero.sp = 0
    battlehero.maxsp = 100

    local res = HeroTable[""..hero.HeroID].Model
    res = string.sub(res,7,#res)
    battlehero.object = GameObject.Instantiate(Resources.Load("Model/"..res))
    return battlehero
end



local t = {}
t.create = create
t.init = init
t.createBattleHero = createBattleHero
t.createBattleEnemy = createBattleEnemy
return t

