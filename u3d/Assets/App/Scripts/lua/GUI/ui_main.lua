
local ui_hero_detail = require "GUI/ui_hero_detail"
local ui_system_bottom = require "GUI/ui_system_bottom"

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3




-- create
local function create()
    local ui_main_obj = nil
    local ui_name = "ui_main"

    local function createObj()
        ui_main_obj = GameObject.Instantiate( Resources.Load("GUI/ui_main") )
        ui_main_obj.name = ui_name
        ui_main_obj.transform:SetParent(UI_Root)
        ui_main_obj.transform.localScale = Vector3.one
        ui_main_obj.transform.localPosition = Vector3.zero
    end

    local function regEvent()
        local btn1 = ui_main_obj.transform:Find("icon/btn1")
        local ev = UI_Event.Get(btn1)
        ev.onClick = {"+=", function( eventData , go , args )
            GameObject.Destroy(ui_main_obj)

            ui_hero_detail.create( function()
                ui_system_bottom.show()
                createObj()
                regEvent()
            end
            )
            ui_system_bottom.hiden()
        end
        }
    end

    createObj()
    regEvent()
end


local t = {}
t.create = create
return t

