
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3
local iTween = iTween
local LuaUtil = LuaUtil
local UI_Event = UI_Event


local function show()
    local mainObj = GameObject("ui_title")
    mainObj.transform:SetParent(UI_Root)
    mainObj.transform.localPosition = Vector3.zero
    mainObj.transform.localScale = Vector3.one

    local obj = Resources.Load("GUI/Title/title_log")
    local background = GameObject.Instantiate( obj )
    background.transform:SetParent(mainObj.transform)
    background.transform.localPosition = Vector3.zero
    background.transform.localScale = Vector3.one

    local btn = GameObject.Instantiate( Resources.Load("GUI/Title/touchText") )
    btn.transform:SetParent(mainObj.transform)
    btn.transform.localPosition = Vector3.zero
    btn.transform.localScale = Vector3.one

    local ev = UI_Event.Get(btn , "11;2")
    ev.onClick = function( eventData , go , args )
        print(" ok in btn click ")
        print(args[1])
        local arg1 = tonumber(args[1])
        print(" arg1 " .. arg1)
    end
    
    iTween.ScaleFrom(btn , Vector3(4,4,1) , 1)
end




local t = {}
t.show = show
return t