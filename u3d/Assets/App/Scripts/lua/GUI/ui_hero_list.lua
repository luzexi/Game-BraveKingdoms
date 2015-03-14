
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources


local ui_hero_list_name = "ui_hero_list"

local MAX_NODE = 6
local MAX_NODE_HERO = 5

local function create()
    local main_obj = nil

    local function createObj()
        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_hero_list"))
        main_obj.name = ui_hero_list_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
        UI_Master = main_obj
    end
    
    local function regEvent()
        local btn_back = main_obj.transform:Find("btn_back")
        local ev = UI_Event.Get(btn_back)
        ev.onClick = {"+=" , function(eventData , go , args)
            GameObject.Destroy(main_obj)
            local ui_hero_menu = require("GUI.ui_hero_menu")
            ui_hero_menu.create()
        end
        }

        local btn_sort = main_obj.transform:Find("btn_sort")
    end

    local function setup_icon( go , hero )
        local bg_dark = go.transform:Find("frame_bg/frame_dark_bg")
        local bg_fire = go.transform:Find("frame_bg/frame_fire_bg")
        local bg_light = go.transform:Find("frame_bg/frame_light_bg")
        local bg_thunder = go.transform:Find("frame_bg/frame_thunder_bg")
        local bg_water = go.transform:Find("frame_bg/frame_water_bg")
        local bg_wood = go.transform:Find("frame_bg/frame_wood_bg")
        bg_dark.gameObject:SetActive(false)
        bg_fire.gameObject:SetActive(false)
        bg_light.gameObject:SetActive(false)
        bg_thunder.gameObject:SetActive(false)
        bg_water.gameObject:SetActive(false)
        bg_wood.gameObject:SetActive(false)
        local frame_bg_array = {bg_fire , bg_water , bg_wood , bg_thunder , bg_light , bg_dark}

        local frame_dark = go.transform:Find("frame/frame_dark")
        local frame_fire = go.transform:Find("frame/frame_fire")
        local frame_light = go.transform:Find("frame/frame_light")
        local frame_thunder = go.transform:Find("frame/frame_thunder")
        local frame_water = go.transform:Find("frame/frame_water")
        local frame_wood = go.transform:Find("frame/frame_wood")
        frame_dark.gameObject:SetActive(false)
        frame_fire.gameObject:SetActive(false)
        frame_light.gameObject:SetActive(false)
        frame_thunder.gameObject:SetActive(false)
        frame_water.gameObject:SetActive(false)
        frame_wood.gameObject:SetActive(false)
        local frame_array = {frame_fire , frame_water , frame_wood , frame_thunder , frame_light , frame_dark}

        local table = HeroTable[""..hero.tableid]
        frame_bg_array[table.Nature].gameObject:SetActive(true)
        frame_array[table.Nature].gameObject:SetActive(true)

        local hero_icon = go.transform:Find("hero"):GetComponent("RawImage")
        hero_icon.texture = Resources.Load("AvatarM/"..table.AvatarM)

        local equip_icon = go.transform:Find("equip")
    end

    local function setup()
        local node = main_obj.transform:Find("node")
        local ui_scroll_list = node:GetComponent("UI_Scroll_List")
        local node_num , node_num_ = math.modf((#Player.heros)/5)
        if node_num_ ~= 0 then
            node_num = node_num + 1
        end
        local res_item = Resources.Load("GUI/ui_hero_item")
        if node_num > MAX_NODE then
            node_num = MAX_NODE
        end
        local j = 1
        for i=1,node_num,1 do
            local node_node = GameObject()
            node_node.name = ""..i
            node_node.transform.parent = node
            node_node.transform.localPosition = Vector3(0,207 - (i-1)*110,0)
            node_node.transform.localScale = Vector3.one
            for k = 0 , MAX_NODE_HERO-1 , 1 do
                local node_node_item = GameObject.Instantiate(res_item)
                node_node_item.name = k
                node_node_item.transform:SetParent(node_node.transform)
                node_node_item.transform.localPosition = Vector3( -250 + k*120,0,0)
                node_node_item.transform.localScale = Vector3.one
                ui_scroll_list:AddDragEvent(node_node_item.gameObject)
                local node_node_ev = UI_Event.Get(node_node_item,""..i..";"..k)
                node_node_ev.onClick = function(eventData , go , args)
                    GameObject.Destroy(main_obj)
                    local ui_hero_detail = require("GUI/ui_hero_detail")
                    local tmp_hero = Player.heros[(tonumber(args[1])-1)*MAX_NODE_HERO+tonumber(args[2])+1]
                    ui_hero_detail.create(tmp_hero , create)
                end
                if j <= #Player.heros then
                    setup_icon(node_node_item,Player.heros[j])
                    j = j +1
                else
                    node_node_item:SetActive(false)
                end
            end
        end
        
        local max_index , max_index_= math.modf((#Player.heros)/MAX_NODE_HERO)
        if max_index_ ~= 0 then
            max_index = max_index + 1
        end
        max_index = max_index - MAX_NODE
        if max_index < 0 then
            max_index = 0
        end

        local function onChange( go , dir )
            local now_index = 1
            if dir == 0 then
                now_index = tonumber(go.name) - MAX_NODE
            else
                now_index = tonumber(go.name) + MAX_NODE
            end
            go.name = ""..now_index
            for i = 0,MAX_NODE_HERO-1,1 do
                local child_item = go.transform:GetChild(i)
                if (now_index-1)*MAX_NODE_HERO+i+1 <= #Player.heros then
                    child_item.gameObject:SetActive(true)
                    UI_Event.Get(child_item,""..now_index..";"..i)
                    setup_icon(child_item.gameObject,Player.heros[(now_index-1)*MAX_NODE_HERO+i+1])
                else
                    child_item.gameObject:SetActive(false)
                end
            end
        end

        local del_onchange = LuaUtil.ToActionGameObjectInt(onChange)

        ui_scroll_list.MaxIndex = max_index
        ui_scroll_list.MaxFixPos = 207
        ui_scroll_list.MinFixPos = -209
        ui_scroll_list.ItemNum = node_num
        ui_scroll_list.ItemCost = 110
        ui_scroll_list:Init()
        ui_scroll_list.onChange = del_onchange
    end

    createObj()
    setup()
    regEvent()
end

local t = {}
t.create = create
return t

