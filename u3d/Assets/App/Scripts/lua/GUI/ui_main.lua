
local ui_hero_detail = require "GUI/ui_hero_detail"
local ui_system_bottom = require "GUI/ui_system_bottom"

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3


local ui_name = "ui_main"

-- create
local function create()
    ui_main_obj = GameObject.Instantiate( Resources.Load("GUI/ui_main") )
    ui_main_obj.name = ui_name
    ui_main_obj.transform:SetParent(UI_Root)
    ui_main_obj.transform.localScale = Vector3.one
    ui_main_obj.transform.localPosition = Vector3.zero

    local btn1 = ui_main_obj.transform:Find("icon/btn1")
    local ev = UI_Event.Get(btn1)
    ev.onClick = {"+=", function( eventData , go , args )
        print("destory ui main obj ")
        if ui_main_obj == nil then
            print(" ui main is nil")
        end
        GameObject.Destroy(ui_main_obj)

        ui_hero_detail.create( function()
            ui_system_bottom.show()
            create()
        end
        )
        ui_system_bottom.hiden()
    end
    }
end


local t = {}
t.create = create
return t

