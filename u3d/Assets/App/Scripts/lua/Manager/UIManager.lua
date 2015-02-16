local GameObject = UnityEngine.GameObject



local function create()
    UI_Root = GameObject.Find("UICamera/Canvas/UI").transform
    UI_SystemRoot = GameObject.Find("UICamera/Canvas/SystemUI").transform
end




local t = {}
t.create = create
return t
