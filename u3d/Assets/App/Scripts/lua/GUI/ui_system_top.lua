
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3



ui_system_top = {}


function ui_system_top:create( )
    local main = GameObject.Instantiate( Resources.Load("GUI/ui_system_top") )
    main.transform:SetParent( UI_Root )
    main.transform.localPosition = Vector3.zero
    main.transform.localScale = Vector3.one
end


return ui_system_top