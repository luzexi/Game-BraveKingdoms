local GameObject = UnityEngine.GameObject



local function start()
    UI_Root = GameObject.Find("UICamera/Canvas/UI").transform
    UI_SystemRoot = GameObject.Find("UICamera/Canvas/SystemUI").transform
end




local t = {}
t.start = start
return t
