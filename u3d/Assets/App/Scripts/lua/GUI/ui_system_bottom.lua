
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3


local UI_Name = "ui_system_bottom"


local function create( )
    local obj = UI_SystemRoot:Find(UI_Name)
    if obj ~= nil then
        return obj.gameObject
    end
    local main = GameObject.Instantiate( Resources.Load("GUI/ui_system_bottom") )
    main.name = UI_Name
    main.transform:SetParent( UI_SystemRoot )
    main.transform.localPosition = Vector3.zero
    main.transform.localScale = Vector3.one
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
