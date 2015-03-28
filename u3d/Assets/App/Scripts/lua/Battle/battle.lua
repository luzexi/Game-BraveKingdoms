
local GameObject = UnityEngine.GameObject;
local Resources = UnityEngine.Resources;
local Vector3 = UnityEngine.Vector3;

local lua_hero = require 'Data.Hero'
local lua_player = require 'Data.Player'
local lua_battlehero = require 'Data.BattleHero'


--get target index
local function get_targetIndex()
    if Battle.autoTarget then
        if Battle.autoIndex >= 1 and Battle.autoIndex <= #Battle.enemys and
            Battle.enemys[Battle.autoIndex] ~= -1 and not Battle.enemys[Battle.autoIndex].dead then
            return Battle.autoIndex
        end
        for i = 1 , #Battle.enemys , 1 do
            if Battle.enemys[i] ~= -1 and not Battle.enemys[i].dead then
                Battle.autoIndex = i
                return Battle.autoIndex
            end
        end
    end
    return Battle.targetIndex
end


local function initdata()
    Battle.gold = 23888
    Battle.soul = 83344
    Battle.crystal = 3433
    Battle.catch_heros = {}
    Battle.heros = {-1,-1,-1,-1,-1,-1}
    Battle.enemys = {-1,-1,-1,-1,-1,-1}
    Battle.gate = 1
    Battle.targetIndex = 1
    Battle.autoTarget = true
    Battle.autoIndex = -1
    Battle.get_targetIndex = get_targetIndex
        

    Battle.node = GameObject.Instantiate(Resources.Load("Battle/BattleObj"))
    Battle.node.transform.localPosition = Vector3.zero;
    Battle.node.transform.localScale = Vector3.one;

    Battle.right_pos = {}
    for i = 1 , 6 , 1 do 
        table.insert(Battle.right_pos , #Battle.right_pos+1 , Battle.node.transform:Find("RightPos/pos"..i))
    end
    Battle.right_attack_pos = {}
    for i = 1 , 6 , 1 do 
        table.insert(Battle.right_attack_pos , #Battle.right_attack_pos+1 , Battle.node.transform:Find("RightAttackPos/pos"..i))
    end
    Battle.left_pos = {}
    for i = 1 , 6 , 1 do 
        table.insert(Battle.left_pos , #Battle.left_pos+1 , Battle.node.transform:Find("LeftPos/pos"..i))
    end
    Battle.left_attack_pos = {}
    for i = 1 , 6 , 1 do 
        table.insert(Battle.left_attack_pos , #Battle.left_attack_pos+1 , Battle.node.transform:Find("LeftAttackPos/pos"..i))
    end

    local scene = GameObject.Instantiate(Resources.Load("Battle/Scene/scene_1"))
    scene.transform.parent = Battle.node.transform
    scene.transform.localPosition = Vector3.zero
    scene.transform.localScale = Vector3.one

    local tmphero = lua_hero.create(234)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)
    tmphero = lua_hero.create(23)
    table.insert(Battle.catch_heros , #Battle.catch_heros + 1, tmphero)
end


local function load_self()
    local self_group_hero = lua_player.getgroup_hero()
    for i = 1 , #self_group_hero , 1 do
        Battle.heros[i] = lua_battlehero.createBattleHero(self_group_hero[i])
    end
end


local function load_enemy( id , gateid )
    if Battle.enemy_table == nil then
        Battle.enemy_table = datatable.getTable("Enemy/Enemy"..id)
    end

    for i , val in pairs(Battle.enemy_table) do
        if Battle.enemy_table[i].GateID == gateid then
            Battle.enemys[Battle.enemy_table[i].OrderID] = lua_battlehero.createBattleEnemy(Battle.enemy_table[i])
        end
    end
end

local function move_start_self()
    for i = 1 , #Battle.heros , 1 do
        if Battle.heros[i] ~= -1 then
            Battle.heros[i].object.transform.parent = Battle.node.transform
            Battle.heros[i].object.transform.localPosition = Battle.right_pos[i].localPosition
            Battle.heros[i].object.transform.localScale = Battle.right_pos[i].localScale
            Battle.heros[i].object:GetComponent("GfxObject"):MoveState( Battle.right_pos[i].localPosition + Vector3(-5,0,0),
            Battle.right_pos[i].localPosition , 1)
        end
    end
end

local function move_next_self()
    --
end

local function move_start_enemy()
    -- set enemy model position
    for i = 1 , #Battle.enemys , 1 do
        if Battle.enemys[i] ~= -1 then
            Battle.enemys[i].object.transform.parent = Battle.node.transform
            Battle.enemys[i].object.transform.localPosition = Battle.left_pos[i].localPosition
            Battle.enemys[i].object.transform.localScale = Battle.left_pos[i].localScale
            Battle.enemys[i].object:GetComponent("GfxObject"):MoveState( Battle.left_pos[i].localPosition + Vector3(5,0,0),
            Battle.left_pos[i].localPosition , 1)
        end
    end
end


local t = {}
t.initdata = initdata
t.load_self = load_self
t.load_enemy = load_enemy
t.move_start_self = move_start_self
t.move_next_self = move_next_self
t.move_start_enemy = move_start_enemy
return t
