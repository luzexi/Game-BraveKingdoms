local GameObject = UnityEngine.GameObject



local function start()
    UI_Root = GameObject.Find("UICamera/Canvas").transform
    UI_SystemRoot = GameObject.Find("UICamera/CanvasSystem").transform
end




local t = {}
t.start = start
return t
