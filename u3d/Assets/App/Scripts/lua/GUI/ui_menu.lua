
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources



local function create()
    local ui_main = require "GUI/ui_main"

    local main_obj = nil
    local ui_name = "ui_menu"

    local function createObj()
        main_obj = GameObject.Instantiate( Resources.Load("GUI/ui_menu") )
        main_obj.name = ui_name
        main_obj.transform:SetParent( UI_Root )
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
        UI_Master = main_obj
    end

    local function regEvent()
        local btn_back = main_obj.transform:Find("btn_back")
        local ev = UI_Event.Get(btn_back)
        ev.onClick = { "+=" , function( eventData , go , args )
            GameObject.Destroy(main_obj)
            ui_main.create()
        end
        }
    end

    createObj()
    regEvent()
end


local t = {}
t.create = create
return t

