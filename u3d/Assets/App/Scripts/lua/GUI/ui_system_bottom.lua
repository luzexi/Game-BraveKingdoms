
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3


local UI_Name = "ui_system_bottom"


local function create()
    local ui_main = require "GUI/ui_main"
    local ui_menu = require "GUI/ui_menu"
    local ui_store = require "GUI/ui_store"
    local ui_hero_menu = require "GUI/ui_hero_menu"
    local ui_gacha = require "GUI/ui_gacha"
    local ui_friend = require 'GUI/ui_friend'

    local obj = UI_SystemRoot:Find(UI_Name)
    if obj ~= nil then
        return obj.gameObject
    end
    local main = GameObject.Instantiate( Resources.Load("GUI/ui_system_bottom") )
    main.name = UI_Name
    main.transform:SetParent( UI_SystemRoot )
    main.transform.localPosition = Vector3.zero
    main.transform.localScale = Vector3.one

    local function regEvent()
        local btn_main = main.transform:Find("frame/btn_main")
        local ev = UI_Event.Get(btn_main)
        ev.onClick = {"+=" , function(eventData , go , args)
            GameObject.Destroy(UI_Master)
            ui_main.create()
        end
        }

        local btn_hero = main.transform:Find("frame/btn_hero")
        ev = UI_Event.Get(btn_hero)
        ev.onClick = {"+=" , function(eventData , go , args)
            GameObject.Destroy(UI_Master)
            ui_hero_menu.create()
        end
        }

        local btn_store = main.transform:Find("frame/btn_store")
        ev = UI_Event.Get(btn_store)
        ev.onClick = {"+=" , function(eventData , go , args)
            GameObject.Destroy(UI_Master)
            ui_store.create()
        end
        }

        local btn_gacha = main.transform:Find("frame/btn_gacha")
        ev = UI_Event.Get(btn_gacha)
        ev.onClick = {"+=" , function(eventData , go , args)
            GameObject.Destroy(UI_Master)
            ui_gacha.create()
        end
        }

        local btn_friend = main.transform:Find("frame/btn_friend")
        ev = UI_Event.Get(btn_friend)
        ev.onClick = function( eventData , go , args )
            GameObject.Destroy(UI_Master)
            ui_friend.create()
        end
    end

    regEvent()

    return main
end

-- show ui
local function show()
    local obj = create()
    obj:SetActive(true)
end


-- hiden ui
local function hiden()
    local obj = UI_SystemRoot:Find(UI_Name)
    if obj ~= nil then
        obj.gameObject:SetActive(false)
    end
end


local t = {}
t.show = show
t.hiden = hiden
return t
