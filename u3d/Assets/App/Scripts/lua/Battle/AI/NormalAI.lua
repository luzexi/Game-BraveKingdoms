
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources
local Random = UnityEngine.Random
local Yield = UnityEngine.Yield
local WaitForSeconds = UnityEngine.WaitForSeconds
local Random = UnityEngine.Random



local ui_data = {}


-- get target index
local function getTargetIndex()
    return 1
end

-- hit call back
local function hitcallback( t_index , s_index , rate , isCombo )
    local damage_font = GameObject.Instantiate(Resources.Load("GUI/Font/damage_font")):GetComponent("Text")
    damage_font.transform:SetParent( ui_data.ui_main.transform )
    local random_pos = Vector3(Random.value*100,Random.value*100,0)
    damage_font.transform.localPosition = ui_data.self_ui_pos[t_index].transform.localPosition + random_pos
    damage_font.transform.localScale = Vector3.one
    damage_font.text = math.modf(rate * Random.value * 9999)
end


-- do attack
local function DoAttack( s_index , enemy )

    local function overcallback( ss_index )
        if Battle.enemys[ss_index].attackNum <= 0 then
            Battle.enemys[ss_index].enable = false

            local finish = true
            for i = 1 , #Battle.enemys , 1 do
                if Battle.enemys[i] ~= -1 and Battle.enemys[i].enable == true then
                    finish = false
                end
            end

            if finish then
                for i = 1 , #Battle.heros , 1 do
                    if Battle.heros[i] ~= -1 and not Battle.heros[i].dead and Battle.heros[i].hp > 0 then
                        Battle.heros[i].enable = true
                        Battle.heros[i].attackNum = 1
                        ui_data.updateInfo(i,Battle.heros[i])
                    end
                end
            end
        else
            DoAttack(ss_index , Battle.enemys[ss_index])
        end
    end

    local c = coroutine.create(function()
        local wait_time = Random.value * 1.5
        Yield(WaitForSeconds(wait_time))

        Battle.enemys[s_index].attackNum = Battle.enemys[s_index].attackNum - 1
        local gfxObj = enemy.object:GetComponent("GfxObject")
        local attacktable = datatable.getTable("HeroAttack")[enemy.tableid]

        local array_hit_time1 = {}
        local array_hit_time2 = {}
        local array_hit_rate = {}
        local target_index = getTargetIndex()
        for j = 1 , (#attacktable.hit)/3 , 1 do
            local hit_time1 = attacktable.hit[(j-1)*3+1] * 0.03333
            local hit_time2 = attacktable.hit[(j-1)*3+2] * 0.03333
            local hit_rate = attacktable.hit[(j-1)*3+3]
            table.insert(array_hit_time1 ,  hit_time1)
            table.insert(array_hit_time2 , hit_time2)
            table.insert(array_hit_rate , hit_rate)
        end
        local targetObj = Battle.heros[target_index].object:GetComponent("GfxObject")
        local targetPos = Battle.right_attack_pos[target_index].transform.localPosition
        local hit_callback = LuaUtil.ToActionIntIntFloatBool(hitcallback)
        local over_callback = LuaUtil.ToActionInt(overcallback)
        gfxObj:AttackState( targetObj , targetPos , target_index , s_index ,
            array_hit_time1 , array_hit_time2 , array_hit_rate ,
            hit_callback , over_callback , true )
    end)
    local ok , ermsg = coroutine.resume(c)
    if not ok then
        print(ermsg)
    end
end

local function init()
    for i = 1 , #Battle.enemys , 1 do
        if Battle.enemys[i] ~= -1 and not Battle.enemys[i].dead then
            Battle.enemys[i].enable = true
            Battle.enemys[i].attackNum = 2
            DoAttack( i , Battle.enemys[i] )
        end
    end
end

local function create( uidata )
    ui_data = uidata
    init()
end



local t = {}
t.create = create
return t


