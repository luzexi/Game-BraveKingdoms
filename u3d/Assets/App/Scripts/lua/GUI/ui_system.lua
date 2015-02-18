
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources

local ui_system_name = "ui_system"


local function create()
    -- creat boby
    local main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_system"))
    main_obj.name = ui_system_name
    main_obj.transform:SetParent(UI_SystemRoot)
    main_obj.transform.localPosition = Vector3.zero
    main_obj.transform.localScale = Vector3.one
end

local function show_collider()
    -- show collider
end


local function hiden_collider()
    -- hiden collider
end


local t = {}
t.create = create
return t
