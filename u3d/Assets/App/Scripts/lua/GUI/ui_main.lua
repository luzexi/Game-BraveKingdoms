

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3



-- create
local function create()
    local obj = GameObject.Instantiate( Resources.Load("GUI/ui_main") )
    obj.transform:SetParent(UI_Root)
    obj.transform.localScale = Vector3.one
    obj.transform.localPosition = Vector3.zero
end


local t = {}
t.create = create
return t

