
local ui_system = require "GUI.ui_system"

local GameObject = UnityEngine.GameObject



local function create()
    UI_Root = GameObject.Find("UICamera/Canvas/UI").transform
    UI_SystemRoot = GameObject.Find("UICamera/Canvas/SystemUI").transform
    UI_BGRoot = GameObject.Find("UICamera/Canvas/BackGroundUI").transform
end




local t = {}
t.create = create
return t
