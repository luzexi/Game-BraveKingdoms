
local GameObject = UnityEngine.GameObject;
local Resources = UnityEngine.Resources;
local Vector3 = UnityEngine.Vector3;


local function initdata()
    Battle = {}
    Battle.gold = 23888
    Battle.soul = 83344
    Battle.crystal = 3433
    Battle.catch_heros = {}
    Battle.heros = {}
    Battle.enemys = {}
    Battle.gate = 1

    local lua_hero = require("Data/Hero")
    local tmphero = lua_hero.create(234)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)
    tmphero = lua_hero.create(23)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)

    local i = 0
    local self_group_hero = Player.getgroup_hero()
    for i = 1 , #self_group_hero , 1 do
        local battlehero = lua_hero.createBattleHero(self_group_hero[i])
        table.insert(Battle.heros , #Battle.heros + 1 , battlehero)
    end
end

local function load_enemy( id , gateid )
    if Battle.enemy_table == nil then
        local table = Resources.Load("Data/Enemy/Table_Enemy"..id)
        local json = require "lib/dkjson"
        Battle.enemy_table = json.decode(table.text)
    end

    local lua_hero = require("Data/Hero")
    Battle.enemys = {}
    local i
    for i , val in pairs(Battle.enemy_table) do
        if Battle.enemy_table[""..i].GateID == gateid then
            local battle_enemy = lua_hero.createBattleEnemy(Battle.enemy_table[""..i])
            table.insert(Battle.enemys , #Battle.enemys+1 , battle_enemy)
        end
    end

end




local t = {}
t.initdata = initdata
t.load_enemy = load_enemy
return t
