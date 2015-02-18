
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources


local ui_background_name = "ui_background"

local function create()
    local main_obj = UI_BGRoot:Find(ui_background_name)
    if main_obj ~= nil then
        return main_obj
    end
    main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_background"))
    main_obj.name = ui_background_name
    main_obj.transform:SetParent(UI_BGRoot)
    main_obj.transform.localPosition = Vector3.zero
    main_obj.transform.localScale = Vector3.one
    return main_obj
end

local function hiden()
    local main_obj = create()
    main_obj.gameObject:SetActive(false)
end

local function show()
    local main_obj = create()
    main_obj.gameObject:SetActive(true)
end

local t = {}
t.show = show
t.hiden = hiden
return t