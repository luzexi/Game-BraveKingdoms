
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources


local ui_hero_list_name = "ui_hero_list"

local function create()
    local main_obj = nil

    local function createObj()
        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_hero_list"))
        main_obj.name = ui_hero_list_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
    end
    
    local function regEvent()
        local btn_back = main_obj.transform:Find("btn_back")
        local ev = UI_Event.Get(btn_back)
        ev.onClick = {"+=" , function(eventData , go , args)
            GameObject.Destroy(main_obj)
            local ui_hero_menu = require("GUI.ui_hero_menu")
            ui_hero_menu.create()
        end
        }

        local btn_sort = main_obj.transform:Find("btn_sort")
    end

    local function setup()
        --
    end

    createObj()
    setup()
    regEvent()
end

local t = {}
t.create = create
return t

