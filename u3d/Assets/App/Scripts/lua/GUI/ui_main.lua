

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3
local Screen = UnityEngine.Screen




-- create
local function create()
    local ui_hero_detail = require "GUI/ui_hero_detail"
    local ui_system_bottom = require "GUI/ui_system_bottom"
    local ui_menu = require "GUI/ui_menu"
    local ui_mail = require "GUI/ui_mail"

    local ui_main_obj = nil
    local ui_name = "ui_main"

    local ratex = SCREEN_WIDE/Screen.width
    local ratey = SCREEN_HEIGHT/Screen.height

    local function createObj()
        ui_main_obj = GameObject.Instantiate( Resources.Load("GUI/ui_main") )
        ui_main_obj.name = ui_name
        ui_main_obj.transform:SetParent(UI_Root)
        ui_main_obj.transform.localScale = Vector3.one
        ui_main_obj.transform.localPosition = Vector3.zero
        UI_Master = ui_main_obj
    end

    local function regEvent()
        local btn = ui_main_obj.transform:Find("icon/btn1")
        local ev = UI_Event.Get(btn)
        ev.onClick = {"+=", function( eventData , go , args )
            GameObject.Destroy(ui_main_obj)

            ui_hero_detail.create( function()
                ui_system_bottom.show()
                createObj()
                regEvent()
            end
            )
            ui_system_bottom.hiden()
        end
        }

        local btn_menu = ui_main_obj.transform:Find("btn_menu")
        ev = UI_Event.Get(btn_menu)
        ev.onClick = {"+=", function( eventData , go , args )
            GameObject.Destroy(ui_main_obj)
            ui_menu.create()
        end
        }

        -- local btn_mail = ui_main_obj.transform:Find("btn_mail")
        -- ev = UI_Event.Get(btn)
        -- ev.onClick = {"+=", function( eventData , go , args )
        --     GameObject.Destroy(ui_main_obj)
        --     ui_mail.create()
        -- end
        -- }

        local quest = ui_main_obj.transform:Find("quest")
        local btn_quest1 = ui_main_obj.transform:Find("quest/quest1")
        local btn_quest2 = ui_main_obj.transform:Find("quest/quest2")
        local btn_quest3 = ui_main_obj.transform:Find("quest/quest3")
        local quest_width = 500

        local function onQuestDown( eventData , go , args )
            print("on quest down " .. go.name)
        end
        local function onQuestMove( eventData , go ,args )
            -- print("on quest move " .. go.name)
            -- quest.localPosition = 
            -- Vector3(quest.localPosition.x + eventData.delta.x*ratex , quest.localPosition.y , quest.localPosition.z)
            
            btn_quest3.localPosition = 
            Vector3(btn_quest3.localPosition.x + eventData.delta.x*ratex , btn_quest3.localPosition.y , btn_quest3.localPosition.z)
            btn_quest2.localPosition = 
            Vector3(btn_quest2.localPosition.x + eventData.delta.x*ratex , btn_quest2.localPosition.y , btn_quest2.localPosition.z)
            btn_quest1.localPosition = 
            Vector3(btn_quest1.localPosition.x + eventData.delta.x*ratex , btn_quest1.localPosition.y , btn_quest1.localPosition.z)

            local function questMove( btn_trans )
                local posx = btn_trans.localPosition.x
                if posx < -1000 then
                    btn_trans.localPosition = Vector3( 500, btn_trans.localPosition.y , btn_trans.localPosition.z )
                end
                if posx > 1000 then
                    btn_trans.localPosition = Vector3( -500, btn_trans.localPosition.y , btn_trans.localPosition.z )
                end
            end
            questMove(btn_quest1)
            questMove(btn_quest2)
            questMove(btn_quest3)
        end
        local function onQuestUp( eventData , go ,args )
            print("onquestup " .. go.name)
        end
        --
        
        ev = UI_Event.Get(btn_quest1)
        ev.onDown = { "+=" , onQuestDown }
        ev.onDrag = { "+=" , onQuestMove }
        ev.onUp = { "+=" , onQuestUp }

        
        ev = UI_Event.Get(btn_quest2)
        ev.onDown = { "+=" , onQuestDown }
        ev.onDrag = { "+=" , onQuestMove }
        ev.onUp = { "+=" , onQuestUp }

        ev = UI_Event.Get(btn_quest3)
        ev.onDown = { "+=" , onQuestDown }
        ev.onDrag = { "+=" , onQuestMove }
        ev.onUp = { "+=" , onQuestUp } 
    end

    createObj()
    regEvent()
end


local t = {}
t.create = create
return t

