
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3

local servers = {}


local function create()
    local main_obj = nil
    main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_friend_search"))
    main_obj.transform:SetParent(UI_Root)
    main_obj.transform.localPosition = Vector3.zero
    main_obj.transform.localScale = Vector3.one
    UI_Master = main_obj

    CBluetooth.Initialize(true , false , nil , nil)

    local search_item = main_obj.transform:Find("search/item")
    search_item.gameObject:SetActive(false)

    local player_obj = main_obj.transform:Find("player")
    player_obj.gameObject:SetActive(false)

    local search_obj = main_obj.transform:Find("search")
    search_obj.gameObject:SetActive(true)

    local player_hero_name = main_obj.transform:Find("player/info/hero_name"):GetComponent("Text")
    local player_hero_hp = main_obj.transform:Find("player/info/hp"):GetComponent("Text")
    local player_hero_attack = main_obj.transform:Find("player/info/attack"):GetComponent("Text")
    local player_hero_defence = main_obj.transform:Find("player/info/defence"):GetComponent("Text")
    local player_hero_recover = main_obj.transform:Find("player/info/recover"):GetComponent("Text")
    local player_hero_lv = main_obj.transform:Find("player/info/lv"):GetComponent("Text")
    local player_hero_img = main_obj.transform:Find("player/info/hero_img"):GetComponent("RawImage")
    local player_name = main_obj.transform:Find("player/info/player_name"):GetComponent("Text")
    local player_lv = main_obj.transform:Find("player/info/player_lv"):GetComponent("Text")
    local player_signature = main_obj.transform:Find("player/info/signature"):GetComponent("Text")

    local function regEvent()
        local btn_back = main_obj.transform:Find("btn_back")
        local ev = UI_Event.Get(btn_back)
        ev.onClick = function()
            GameObject.Destroy(main_obj)
            CBluetooth.DeInitialize(nil)
            local lua_friend = require "GUI/ui_friend"
            lua_friend.create()
        end
        local btn_search_start = main_obj.transform:Find("search/btn_search_start")
        ev = UI_Event.Get(btn_search_start)
        ev.onClick = function(eventData , go , args)
            print("start search")
            if #servers > 0 then
                for server_item in servers do
                    GameObject.Destroy(server_item.obj)
                end
            end
            servers = {}
            local scan_start_callback = function(arg1 , arg2)
                CBluetooth.Log("name " ..arg1 .. " address " .. arg2)
                local item_obj = GameObject.Instantiate(search_item.gameObject)
                item_obj:SetActive(true)
                item_obj.transform:SetParent(search_obj)
                item_obj.transform.localPosition = Vector3(0,(#servers)*40,0)
                item_obj.transform.localScale = Vector3.one
                local item_lab = item_obj.transform:Find("Button/Text"):GetComponent("Text")
                item_lab.text = ""..arg1.." : "..arg2

                local ev_item = UI_Event.Get(item_obj)
                ev_item.onClick = function(eventData , go , args)
                    local bluetooth_connect_callback = function(con_arg1)
                        CBluetooth.Log("connect ok")
                    end
                    bluetooth_connect_callback = LuaUtil.ToActionStr(bluetooth_connect_callback)

                    local bluetooth_connect_service_callback = function(ser_arg1 , ser_arg2)
                        CBluetooth.Log("service ok : arg1 "..ser_arg1.." arg2 "..ser_arg2)
                    end
                    bluetooth_connect_service_callback = LuaUtil.ToActionStrStr(bluetooth_connect_service_callback)

                    local bluetooth_connect_characteristic_callback = function(cha_arg1 , cha_arg2 , cha_arg3)
                        if cha_arg2 == BLUETOOTH_SERVER_ID and cha_arg3 == BLUETOOTH_READ_ID then
                            local notificationAction = function(notif_arg1)
                                CBluetooth.Log(notif_arg1)
                            end
                            notificationAction = LuaUtil.ToActionStr(notificationAction)

                            local subscribe_action = function(sub_arg1 , sub_arg2)
                                CBluetooth.Log("sub arg1 :"..sub_arg1.." arg2 "..sub_arg2)
                            end
                            subscribe_action = LuaUtil.ToActionStrStr(subscribe_action)
                            CBluetooth.SubscribeCharacteristic(arg1, BLUETOOTH_SERVER_ID, BLUETOOTH_READ_ID, notificationAction, subscribe_action)
                        end
                    end
                    bluetooth_connect_characteristic_callback = LuaUtil.ToActionStrStrStr(bluetooth_connect_characteristic_callback)
                    CBluetooth.ConnectToPeripheral(arg2,bluetooth_connect_callback,
                        bluetooth_connect_service_callback,bluetooth_connect_characteristic_callback)
                end
                table.insert(servers,{name=arg1,address=arg2,obj=item_obj})
            end
            scan_start_callback = LuaUtil.ToActionStrStr(scan_start_callback)
            CBluetooth.ScanForPeripheralsWithServices({BLUETOOTH_SERVER_ID} , scan_start_callback)
        end

        local btn_search_stop = main_obj.transform:Find("search/btn_search_stop")
        ev = UI_Event.Get(btn_search_stop)
        ev.onClick = function(eventData , go , args)
            print("stop search")
            CBluetooth.StopScan()
            if #servers > 0 then
                for server_item in servers do
                    GameObject.Destroy(server_item.obj)
                end
            end
            servers = {}
        end

        btn_search_stop.gameObject:SetActive(false)

        local btn_player_apply = main_obj.transform:Find("player/btn_apply")
        ev = UI_Event.Get(btn_player_apply)
        ev.onClick = function(eventData , go , args)
            print("apply player")
        end
    end

    regEvent()
end



local t={}
t.create = create
return t
