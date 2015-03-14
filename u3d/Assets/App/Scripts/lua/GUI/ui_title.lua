
local lua_http = require "Util/lua_http"
local game_scene = require "Scene/GameScene"

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3
local iTween = iTween
local LuaUtil = LuaUtil
local UI_Event = UI_Event
local Network = Network;


-- create
local function create()
    local main = GameObject.Instantiate( Resources.Load("GUI/ui_title") )
    main.transform:SetParent(UI_Root)
    main.transform.localPosition = Vector3.zero
    main.transform.localScale = Vector3.one

    local btn = main.transform:Find("touchText")

    local ev = UI_Event.Get(btn)
    ev.onClick = {"+=" , function( eventData , go , args )
        GameObject.Destroy(main)
        game_scene.create()
    end
    }
    
    -- iTween.ScaleFrom(btn , Vector3(4,4,1) , 1)
end




local t = {}
t.create = create
return t