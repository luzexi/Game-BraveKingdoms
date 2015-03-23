
local GameObject = UnityEngine.GameObject;
local Resources = UnityEngine.Resources;
local Vector3 = UnityEngine.Vector3;

local lua_hero = require 'Data.Hero'
local lua_battlehero = require 'Data.BattleHero'


local function initdata()
    Battle.gold = 23888
    Battle.soul = 83344
    Battle.crystal = 3433
    Battle.catch_heros = {}
    Battle.heros = {nil,nil,nil,nil,nil}
    Battle.enemys = {nil,nil,nil,nil,nil}
    Battle.gate = 1
    Battle.targetIndex = 1
    Battle.autoTarget = false
    Battle.autoIndex = 1

    local tmphero = lua_hero.create(234)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)
    tmphero = lua_hero.create(23)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)
end


local function load_self()

    local i = 0
    local self_group_hero = Player.getgroup_hero()
    for i = 1 , #self_group_hero , 1 do
        Battle.heros[i] = lua_battlehero.createBattleHero(self_group_hero[i])
    end
end


local function load_enemy( id , gateid )
    if Battle.enemy_table == nil then
        local table = Resources.Load("Data/Enemy/Table_Enemy"..id)
        local json = require "lib/dkjson"
        Battle.enemy_table = json.decode(table.text)
    end

    local i
    for i , val in pairs(Battle.enemy_table) do
        if Battle.enemy_table[""..i].GateID == gateid then
            Battle.enemys[Battle.enemy_table[""..i].OrderID] = lua_battlehero.createBattleEnemy(Battle.enemy_table[""..i])
        end
    end

end




local t = {}
t.initdata = initdata
t.load_self = load_self
t.load_enemy = load_enemy
return t
