

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3
local Random = UnityEngine.Random
local Yield = UnityEngine.Yield
local WaitForSeconds = UnityEngine.WaitForSeconds


local battle_lua = require 'Battle.battle'

local main_obj = nil
local battle_obj = nil

local front_collider = nil

local enemy_ui_pos = {}
local self_ui_pos = {}


-- update top num
local function updateTop()
    local soul_text = main_obj.transform:Find("battle/soul_text"):GetComponent("Text")
    soul_text.text = Battle.soul
    local gold_text = main_obj.transform:Find("battle/gold_text"):GetComponent("Text")
    gold_text.text = Battle.gold
    local hero_text = main_obj.transform:Find("battle/hero_text"):GetComponent("Text")
    hero_text.text = #Battle.catch_heros
    local crystal_text = main_obj.transform:Find("battle/crystal_text"):GetComponent("Text")
    crystal_text.text = Battle.crystal
end

-- update target info
local function updateTarget()
    --
end

-- select target index
local function setTarget( index )
    local target_icon = main_obj.transform:Find("battle/target")
    if not Battle.autoTarget and index == Battle.targetIndex then
        target_icon.gameObject:SetActive(false)
        Battle.autoTarget = true
        Battle.targetIndex = -1
    else
        if index <= 6 and Battle.enemys[index] ~= nil and Battle.enemys[index].hp > 0 then
            Battle.autoTarget = false
            local pos_ary = { Vector3(-100,244,0) , Vector3(-101,117,0) , Vector3(-157,170,0) ,
            Vector3(-211,220,0) , Vector3(-220,111,0) , Vector3(-275,183,0) }
            target_icon.gameObject:SetActive(true)
            target_icon.localPosition = pos_ary[index]
            Battle.targetIndex = index
        end
    end
end

-- select self index
local function setMyself( index )
    print("self btn "..index)
end

local function setInfo( index ,  battle_hero )
    local icon_obj = main_obj.transform:Find("icon")
    local battle_obj = main_obj.transform:Find("battle")
    local item_obj = main_obj.transform:Find("item_frame")

    local icon = icon_obj:Find("icon"..index)
    local icon_img = icon:Find("icon")
    local property = icon:Find("property")
    local frame_bg = icon:Find("frame_bg")
    local hp_obj = icon:Find("hp")
    local hp_text = icon:Find("hp/hp_img/hp_text")
    local hp_bar = icon:Find("hp/Scrollbar")
    local sp_obj = icon:Find("sp")
    local sp_text = icon:Find("sp/sp_img/sp_text")
    local sp_bar = icon:Find("sp/Scrollbar")
    local name = icon:Find("name")
    local cover_black = icon:Find("cover_black")
    local empty = icon:Find("empty")
    local dead = icon:Find("dead")
    local frame_icon = icon:Find("frame/frame")
    local frame_empty = icon:Find("frame/frame_empty")

    local frame_bg_water = frame_bg:Find("bg_water")
    local frame_bg_wood = frame_bg:Find("bg_wood")
    local frame_bg_fire = frame_bg:Find("bg_fire")
    local frame_bg_thunder = frame_bg:Find("bg_thunder")
    local frame_bg_dark = frame_bg:Find("bg_dark")
    local frame_bg_light = frame_bg:Find("bg_light")
    local frame_bg_black = frame_bg:Find("bg_black")
    local frame_bg_array = {frame_bg_fire , frame_bg_water , frame_bg_wood , frame_bg_thunder , frame_bg_light , frame_bg_dark}

    frame_bg_water.gameObject:SetActive(false)
    frame_bg_wood.gameObject:SetActive(false)
    frame_bg_fire.gameObject:SetActive(false)
    frame_bg_thunder.gameObject:SetActive(false)
    frame_bg_dark.gameObject:SetActive(false)
    frame_bg_light.gameObject:SetActive(false)
    frame_bg_black.gameObject:SetActive(false)

    local property_water = property:Find("water")
    local property_fire = property:Find("fire")
    local property_wood = property:Find("wood")
    local property_thunder = property:Find("thunder")
    local property_light = property:Find("light")
    local property_dark = property:Find("dark")
    local property_arr = {property_fire , property_water , property_wood , property_thunder , property_light , property_dark}
    property_water.gameObject:SetActive(false)
    property_fire.gameObject:SetActive(false)
    property_wood.gameObject:SetActive(false)
    property_thunder.gameObject:SetActive(false)
    property_light.gameObject:SetActive(false)
    property_dark.gameObject:SetActive(false)


    cover_black.gameObject:SetActive(false)
    if battle_hero == nil then
        icon_img.gameObject:SetActive(false)
        frame_bg_black.gameObject:SetActive(true)
        property.gameObject:SetActive(false)
        hp_obj.gameObject:SetActive(false)
        sp_obj.gameObject:SetActive(false)
        name.gameObject:SetActive(false)
        empty.gameObject:SetActive(true)
        dead.gameObject:SetActive(false)
        frame_icon.gameObject:SetActive(false)
        frame_empty.gameObject:SetActive(true)
    else
        frame_icon.gameObject:SetActive(true)
        frame_empty.gameObject:SetActive(false)

        local table = datatable.getTable("Hero")[battle_hero.tableid]

        icon_img.gameObject:GetComponent("RawImage").texture = Resources.Load("AvatarM/"..table.AvatarM)

        property_arr[table.Nature].gameObject:SetActive(true)
        frame_bg_array[table.Nature].gameObject:SetActive(true)
        name:GetComponent("Text").text = table.Name
        empty.gameObject:SetActive(false)
        dead.gameObject:SetActive(false)
        hp_text:GetComponent("Text").text = ""..battle_hero.hp.."/"..battle_hero.maxhp
        hp_bar:GetComponent("Scrollbar").size = battle_hero.hp / battle_hero.maxhp
        sp_text:GetComponent("Text").text = ""..battle_hero.sp.."/"..battle_hero.maxsp
        sp_bar:GetComponent("Scrollbar").size = battle_hero.sp / battle_hero.maxsp
    end
end


local function updateInfo( index ,  battle_hero )
    local icon_obj = main_obj.transform:Find("icon")

    local icon = icon_obj:Find("icon"..index)
    local hp_text = icon:Find("hp/hp_img/hp_text")
    local hp_bar = icon:Find("hp/Scrollbar")
    local sp_text = icon:Find("sp/sp_img/sp_text")
    local sp_bar = icon:Find("sp/Scrollbar")
    local dead = icon:Find("dead")
    local cover_black = icon:Find("cover_black")

    if battle_hero ~= nil and battle_hero ~= -1 then

        local table = datatable.getTable("Hero")[battle_hero.tableid]

        if battle_hero.dead then
            dead.gameObject:SetActive(true)
        else
            dead.gameObject:SetActive(false)
        end

        if battle_hero.attackNum > 0 then
            cover_black.gameObject:SetActive(false)
        else
            cover_black.gameObject:SetActive(true)
        end
        hp_text:GetComponent("Text").text = ""..battle_hero.hp.."/"..battle_hero.maxhp
        hp_bar:GetComponent("Scrollbar").size = battle_hero.hp / battle_hero.maxhp
        sp_text:GetComponent("Text").text = ""..battle_hero.sp.."/"..battle_hero.maxsp
        sp_bar:GetComponent("Scrollbar").size = battle_hero.sp / battle_hero.maxsp
    end
end


local function hitcallback( t_index , s_index , rate , isCombo )
    local damage_font = GameObject.Instantiate(Resources.Load("GUI/Font/damage_font")):GetComponent("Text")
    damage_font.transform:SetParent( main_obj.transform )
    local random_pos = Vector3(Random.value*100,Random.value*100,0)
    damage_font.transform.localPosition = enemy_ui_pos[t_index].transform.localPosition + random_pos
    damage_font.transform.localScale = Vector3.one
    damage_font.text = math.modf(rate * Random.value * 9999)
end

local function overcallback( s_index )
    Battle.heros[s_index].attackNum = 1
    updateInfo(s_index , Battle.heros[s_index])
end


local function create()
    local ui_name = "ui_battle"

    local function createObj()
        main_obj = UI_Root:Find(ui_name)
        if main_obj ~= nil then
            main_obj = main_obj.gameObject
            return main_obj
        end

        local battle_camera = Battle.node.transform:Find("BattleCamera"):GetComponent("Camera")

        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_battle"))
        main_obj.name = ui_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one

        front_collider = main_obj.transform:Find("front_collider")
        local c=coroutine.create(function()
            Yield(WaitForSeconds(2))
            front_collider.gameObject:SetActive(false)
        end)
        coroutine.resume(c)

        enemy_ui_pos = {}
        for i = 1 , 6 , 1 do
            local pos = main_obj.transform:Find("select/enemy/btn"..i)
            table.insert(enemy_ui_pos , #enemy_ui_pos+1 , pos)
        end
        self_ui_pos = {}
        for i = 1 , 6 , 1 do
            local pos = main_obj.transform:Find("select/self/btn"..i)
            table.insert(self_ui_pos , #self_ui_pos+1 , pos)
        end

        local rendtexture = main_obj.transform:Find("rendtexture"):GetComponent("RawImage")
        rendtexture.texture = battle_camera.targetTexture

        updateTop()

        -- set icon btn event
        local i = 1
        for i = 1 , #Battle.heros , 1 do
            if Battle.heros[i] ~= -1 then
                setInfo(i,Battle.heros[i])
                local icon_btn = main_obj.transform:Find("icon/icon"..i.."/btn")
                icon_btn = UI_Event.Get(icon_btn,""..i)
                icon_btn.onClick = function(eventData , go , args)
                    local icon_index = tonumber(args[1])
                    if Battle.heros[icon_index].attackNum > 0 then
                        Battle.heros[icon_index].attackNum = 0
                        updateInfo(icon_index , Battle.heros[icon_index])
                        local gfxObj = Battle.heros[icon_index].object:GetComponent("GfxObject")
                        local attacktable = datatable.getTable("HeroAttack")[Battle.heros[icon_index].tableid]
                        local array_hit_time1 = {}
                        local array_hit_time2 = {}
                        local array_hit_rate = {}
                        local target_index = Battle.get_targetIndex()
                        for j = 1 , (#attacktable.hit)/3 , 1 do
                            local hit_time1 = attacktable.hit[(j-1)*3+1] * 0.03333
                            local hit_time2 = attacktable.hit[(j-1)*3+2] * 0.03333
                            local hit_rate = attacktable.hit[(j-1)*3+3]
                            table.insert(array_hit_time1 ,  hit_time1)
                            table.insert(array_hit_time2 , hit_time2)
                            table.insert(array_hit_rate , hit_rate)
                        end
                        local targetObj = Battle.enemys[target_index].object:GetComponent("GfxObject")
                        local targetPos = Battle.left_attack_pos[target_index].transform.localPosition

                        hit_callback = LuaUtil.ToActionIntIntFloatBool(hitcallback)
                        over_callback = LuaUtil.ToActionInt(overcallback)
                        gfxObj:AttackState( targetObj , targetPos , target_index , icon_index ,
                            array_hit_time1 , array_hit_time2 , array_hit_rate ,
                            hit_callback , over_callback , true )
                    end
                end
            else
                setInfo(i,nil)
            end
        end

        -- set selece enemy btn
        for i = 1 , 6 , 1 do
            local enemy_btn = main_obj.transform:Find("select/enemy/btn"..i)
            enemy_btn = UI_Event.Get(enemy_btn , ""..i)
            enemy_btn.onClick = function(eventData , go , args)
                local tmpindex = tonumber(args[1])
                setTarget(tmpindex)
            end
        end

        -- set selece self btn
        for i = 1 , 6 , 1 do
            local self_btn = main_obj.transform:Find("select/self/btn"..i)
            self_btn = UI_Event.Get(self_btn , ""..i)
            self_btn.onClick = function(eventData , go , args)
                local tmpindex = tonumber(args[1])
                setMyself(tmpindex)
            end
        end

        return main_obj
    end

    local function regEvent()
        --
    end

    main_obj = createObj()

    battle_lua.move_start_self()
    battle_lua.move_start_enemy()
    setTarget(Battle.get_targetIndex())
end

local t = {}
t.create = create
t.updateInfo = updateInfo
t.updateTop = updateTop
return t
