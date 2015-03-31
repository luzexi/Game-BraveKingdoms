

local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources



local function create()
    local main_obj = nil

    main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_friend_apply"))
    main_obj.transform:SetParent(UI_Root)
    main_obj.transform.localPosition = Vector3.zero
    main_obj.transform.localScale = Vector3.one
    UI_Master = main_obj

    local player_obj = main_obj.transform:Find("player")
    player_obj.gameObject:SetActive(false)

    local player_hero_name = main_obj.transform:Find("player/info/hero_name"):GetComponent("Text")
    local player_hero_hp = main_obj.transform:Find("player/info/hp"):GetComponent("Text")
    local player_hero_attack = main_obj.transform:Find("player/info/attack"):GetComponent("Text")
    local player_hero_defence = main_obj.transform:Find("player/info/defence"):GetComponent("Text")
    local player_hero_recover = main_obj.transform:Find("player/info/recover"):GetComponent("Text")
    local player_hero_lv = main_obj.transform:Find("player/info/lv"):GetComponent("Text")
    local player_hero_img = main_obj.transform:Find("player/info/hero_img"):GetComponent("RawImage")
    local player_name = main_obj.transform:Find("player/info/player_name"):GetComponent("Text")
    local player_lv = main_obj.transform:Find("player/info/player_lv"):GetComponent("Text")
    local player_signature = main_obj.transform:Find("player/info/signature"):GetComponent("Text")

    local function regEvent()
        local btn_back = main_obj.transform:Find("btn_back")
        local ev = UI_Event.Get(btn_back)
        ev.onClick = function(eventData , go , args)
            GameObject.Destroy(main_obj)
            local lua_friend = require 'GUI/ui_friend'
            lua_friend.create()
        end

        local btn_start = main_obj.transform:Find("btn_start")
        ev = UI_Event.Get(btn_start)
        ev.onClick = function(eventData , go ,args)
            print("btn start")
        end

        local btn_stop = main_obj.transform:Find("btn_stop")
        ev = UI_Event.Get(btn_stop)
        ev.onClick = function(eventData , go , args)
            print("btn stop")
        end
    end

    regEvent()
end



local t = {}
t.create = create
return t