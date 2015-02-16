

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3


local function create()
    local ui_main = require "GUI/ui_main"

    local main_obj = nil
    local ui_name = "ui_main"

    local function createObj()
        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_gacha"))
        main_obj.name = ui_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
        UI_Master = main_obj
    end

    local function regEvent()
        local btn_left = main_obj.transform:Find("arrowLeft")
        local ev = UI_Event.Get(btn_left)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("ok in btn left")
        end
        }
        local btn_right = main_obj.transform:Find("arrowRight")
        ev = UI_Event.Get(btn_right)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("ok in btn right")
        end
        }
    end

    createObj()
    regEvent()
end

local t = {}
t.create = create
return t

