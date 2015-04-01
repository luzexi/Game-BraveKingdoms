

local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources



local function create()
    local main_obj = nil

    main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_friend_apply"))
    main_obj.transform:SetParent(UI_Root)
    main_obj.transform.localPosition = Vector3.zero
    main_obj.transform.localScale = Vector3.one
    UI_Master = main_obj

    local bluetooth_init_callback = function()
        CBluetooth.Log("init ok")
    end
    bluetooth_init_callback = LuaUtil.ToAction(bluetooth_init_callback)
    local bluetooth_init_error_callback = function(error_str)
        CBluetooth.Log("init error : " .. error_str)
    end
    bluetooth_init_error_callback = LuaUtil.ToActionStr(bluetooth_init_error_callback)
    CBluetooth.Initialize(false , true , bluetooth_init_callback , bluetooth_init_error_callback)

    local player_obj = main_obj.transform:Find("player")
    player_obj.gameObject:SetActive(false)

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
        ev.onClick = function(eventData , go , args)
            GameObject.Destroy(main_obj)
            CBluetooth.DeInitialize(nil)
            local lua_friend = require 'GUI/ui_friend'
            lua_friend.create()
        end

        local btn_start = main_obj.transform:Find("btn_start")
        ev = UI_Event.Get(btn_start)
        ev.onClick = function(eventData , go ,args)
            CBluetooth.Log("btn start")
            CBluetooth.PeripheralName("bf bulutooth")
            local create_read_characteristic_callback = function( c_arg1 , c_arg2 )
                CBluetooth.Log("ok in create read characteristic callback : arg2 " .. c_arg2)
            end
            create_read_characteristic_callback = LuaUtil.ToActionStrStr(create_read_characteristic_callback)
            CBluetooth.CreateReadCharacteristic(BLUETOOTH_READ_ID,"1",create_read_characteristic_callback)

            local create_write_characteristic_callback = function( c_arg1 , c_arg2 )
                CBluetooth.Log("ok in create write characteristic callback : arg2 " .. c_arg2)
            end
            create_write_characteristic_callback = LuaUtil.ToActionStrStr(create_write_characteristic_callback)
            CBluetooth.CreateWriteCharacteristic(BLUETOOTH_WRITE_ID,"2",create_write_characteristic_callback)

            --create service
            local start_advertising_callback = function(arg1)
                CBluetooth.Log("ok start advertising : arg1 " .. arg1)
            end
            start_advertising_callback = LuaUtil.ToAction(start_advertising_callback)
            local create_service_callback = function(arg1)
                CBluetooth.Log(" ok create service callback : arg1 " .. arg1)
                CBluetooth.StartAdvertising(start_advertising_callback)
            end
            create_service_callback = LuaUtil.ToActionStr(create_service_callback)
            CBluetooth.CreateService(BLUETOOTH_SERVER_ID,false,create_service_callback)
            
        end

        local btn_stop = main_obj.transform:Find("btn_stop")
        ev = UI_Event.Get(btn_stop)
        ev.onClick = function(eventData , go , args)
            CBluetooth.Log("btn stop")
            CBluetooth.StopAdvertising(nil)
        end
    end

    regEvent()
end



local t = {}
t.create = create
return t