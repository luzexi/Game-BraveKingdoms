

local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources


local function create()
    local main_obj = nil
    local ui_name = "ui_friend"

    main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_friend"))
    main_obj.name = ui_name
    main_obj.transform:SetParent(UI_Root)
    main_obj.transform.localPosition = Vector3.zero
    main_obj.transform.localScale = Vector3.one
    UI_Master = main_obj

    local btn_apply = main_obj.transform:Find("menu/apply")
    local btn_list = main_obj.transform:Find("menu/list")
    local btn_gift = main_obj.transform:Find("menu/gift")
    local btn_search = main_obj.transform:Find("menu/search")
    local btn_chat = main_obj.transform:Find("menu/chat")

    local ev = UI_Event.Get(btn_apply)
    ev.onClick = function( eventdata , go , args )
        GameObject.Destroy(main_obj)
        local lua_friend_apply = require 'GUI/ui_friend_apply'
        lua_friend_apply.create()
    end

    ev = UI_Event.Get(btn_list)
    ev.onClick = function( eventdata , go , args )
        print("btn list")
    end

    ev = UI_Event.Get(btn_gift)
    ev.onClick = function( eventData , go , args )
        print("btn gift")
    end

    ev = UI_Event.Get(btn_search)
    ev.onClick = function( eventData , go , args )
        GameObject.Destroy(main_obj)
        local lua_friend_search = require 'GUI/ui_friend_search'
        lua_friend_search.create()
    end

    ev = UI_Event.Get(btn_chat)
    ev.onClick = function( eventdata , go , args )
        print("btn chat")
    end
end



local t={}
t.create = create
return t
