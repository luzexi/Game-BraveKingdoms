
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources


local function create()
    local main_obj = nil
    local ui_name = "ui_quest"
    local MAX_NODE = 5

    local function createObj()
        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_quest"))
        main_obj.name = ui_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
        UI_Master = main_obj
    end

    local function setup()
        local node = main_obj.transform:Find("node")
        local ui_scroll_list = node:GetComponent("UI_Scroll_List")
        local node_num , node_num_ = #QuestTable
        local res_item = Resources.Load("GUI/ui_quest_item")
        if node_num > MAX_NODE then
            node_num = MAX_NODE
        end

        local function setup_icon( go , quest , clear ,index)
            local title_txt = go.transform:Find("title"):GetComponent("Text")
            local desc_txt = go.transform:Find("desc"):GetComponent("Text")
            local clear_go = go.transform:Find("clear").gameObject
            local new_go = go.transform:Find("new").gameObject

            title_txt.text = quest.name
            desc_txt.text = quest.desc
            if clear then
                new_go:SetActive(false)
                clear_go:SetActive(true)
            else
                new_go:SetActive(true)
                clear_go:SetActive(false)
            end

            local node_event = UI_Event.Get(go,""..index)
            node_event.onClick = function(eventData , go , args)
                
                local quest_index = tonumber(args[1])
                print("quest index -- " .. quest_index)
                GameObject.Destroy(main_obj)
                main_obj = nil

                Battle.quest_table = QuestTable[quest_index]
                local battle_scene = require("Scene.BattleScene")
                battle_scene.create()
            end
        end

        for i=1,node_num,1 do
            local node_node = GameObject.Instantiate(res_item)
            node_node.name = ""..i
            node_node.transform:SetParent(node)
            node_node.transform.localPosition = Vector3(0,233 - (i-1)*153,0)
            node_node.transform.localScale = Vector3.one
            setup_icon(node_node,QuestTable[i],true,i)
        end
        
        local max_index , max_index_= #QuestTable
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
            setup_icon(go,QuestTable[now_index],true,now_index)
        end

        local del_onchange = LuaUtil.ToActionGameObjectInt(onChange)

        ui_scroll_list.MaxIndex = max_index
        ui_scroll_list.MaxFixPos = 223
        ui_scroll_list.MinFixPos = -252
        ui_scroll_list.ItemNum = node_num
        ui_scroll_list.ItemCost = 153
        ui_scroll_list:Init()
        ui_scroll_list.onChange = del_onchange
    end

    createObj()
    setup()
end


local t = {}
t.create = create
return t



