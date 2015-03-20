

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3


local main_obj = nil

local function updateInfo( index ,  battle_hero )
    -- local main_obj = createObj()
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

        local table = HeroTable[""..battle_hero.tableid]

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

local function create()
    local ui_name = "ui_battle"

    local function createObj()
        main_obj = UI_Root:Find(ui_name)
        if main_obj ~= nil then
            main_obj = main_obj.gameObject
            return main_obj
        end
        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_battle"))
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
        local lua_battle = require("Battle/battle.lua")
        lua_battle.initdata()

        local i = 0
        for i = 1 , 6 , 1 do
            if i <= #Battle.heros then
                updateInfo(i,Battle.heros[i])
            else
                updateInfo(i,nil)
            end
        end

        return main_obj
    end

    local function regEvent()
        --
    end

    main_obj = createObj()
end

local t = {}
t.create = create
t.updateInfo = updateInfo
return t
