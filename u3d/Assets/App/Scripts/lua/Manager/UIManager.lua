
local ui_system = require "GUI.ui_system"

local GameObject = UnityEngine.GameObject
local Screen = UnityEngine.Screen



local function create()
    UI_Root = GameObject.Find("UICamera/UICanvas").transform
    UI_SystemRoot = GameObject.Find("UICamera/SystemCanvas").transform
    UI_BGRoot = GameObject.Find("UICamera/BackgroundCanvas").transform

    local canvasScalerRoot = UI_Root:GetComponent("CanvasScaler")
    local canvasScalerSystem = UI_SystemRoot:GetComponent("CanvasScaler")
    local canvasBG = UI_BGRoot:GetComponent("CanvasScaler")

    local target_rate = 640/960
    local now_rate = Screen.width / Screen.height
    if target_rate < now_rate then
        canvasScalerRoot.matchWidthOrHeight = 1
        canvasScalerSystem.matchWidthOrHeight = 1
        canvasBG.matchWidthOrHeight = 1
    else
        canvasScalerRoot.matchWidthOrHeight = 0
        canvasScalerSystem.matchWidthOrHeight = 0
        canvasBG.matchWidthOrHeight = 0
    end
end




local t = {}
t.create = create
return t
