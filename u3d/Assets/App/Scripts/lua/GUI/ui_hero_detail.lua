
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3

local ui_name = "ui_hero_detail"

local function create( func )
    ui_hero_detail = GameObject.Instantiate( Resources.Load("GUI/ui_hero_detail") )
    ui_hero_detail.name = ui_name
    ui_hero_detail.transform:SetParent(UI_Root)
    ui_hero_detail.transform.localPosition = Vector3.zero
    ui_hero_detail.transform.localScale = Vector3.one

    local collider = ui_hero_detail.transform:Find("collider")
    local ev = UI_Event.Get(collider)
    ev.onClick = {"+=",function(eventData , go , args)
        GameObject.Destroy(ui_hero_detail)
        func()
    end
    }
end




local t = {}
t.create = create
return t
