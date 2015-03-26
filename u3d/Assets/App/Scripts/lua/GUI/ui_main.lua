

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

    local hero_table = datatable.getTable("Hero")

    local function createObj()
        ui_main_obj = GameObject.Instantiate( Resources.Load("GUI/ui_main") )
        ui_main_obj.name = ui_name
        ui_main_obj.transform:SetParent(UI_Root)
        ui_main_obj.transform.localScale = Vector3.one
        ui_main_obj.transform.localPosition = Vector3.zero
        UI_Master = ui_main_obj
    end

    local function updateInfo()

        local function set_icon( trans , hero )
            local back = trans:Find("back")
            local dark = trans:Find("dark")
            local fire = trans:Find("fire")
            local light = trans:Find("light")
            local thunder = trans:Find("thunder")
            local water = trans:Find("water")
            local wood = trans:Find("wood")
            back.gameObject:SetActive(false)
            dark.gameObject:SetActive(false)
            fire.gameObject:SetActive(false)
            light.gameObject:SetActive(false)
            thunder.gameObject:SetActive(false)
            water.gameObject:SetActive(false)
            wood.gameObject:SetActive(false)
            ar_property = {fire , water , wood , thunder , light , dark}
            if hero ~= nil then
                local table = hero_table[hero.tableid]
                local property = ar_property[table.Nature]
                property.gameObject:SetActive(true)
            else
                back.gameObject:SetActive(true)
            end
        end

        local function set_property( trans , hero )
            local dark = trans:Find("dark")
            local fire = trans:Find("fire")
            local light = trans:Find("light")
            local thunder = trans:Find("thunder")
            local water = trans:Find("water")
            local wood = trans:Find("wood")
            dark.gameObject:SetActive(false)
            fire.gameObject:SetActive(false)
            light.gameObject:SetActive(false)
            thunder.gameObject:SetActive(false)
            water.gameObject:SetActive(false)
            wood.gameObject:SetActive(false)
            ar_property = {fire , water , wood , thunder , light , dark}
            if hero ~= nil then
                local table = hero_table[hero.tableid]
                local property = ar_property[table.Nature]
                property.gameObject:SetActive(true)
            end
        end

        local function set_card( trans , hero )
            if hero ~= nil then
                local ui_img = trans:GetComponent("RawImage")
                local table = hero_table[hero.tableid]
                ui_img.texture = Resources.Load("AvatarL/"..table.AvatarL)
            else
                trans.gameObject:SetActive(false)
            end
        end

        local icon1 = ui_main_obj.transform:Find("icon/icon1")
        local icon2 = ui_main_obj.transform:Find("icon/icon2")
        local icon3 = ui_main_obj.transform:Find("icon/icon3")
        local icon4 = ui_main_obj.transform:Find("icon/icon4")
        local icon5 = ui_main_obj.transform:Find("icon/icon5")

        set_icon(icon1 , Player.gethero_by_group(1))
        set_icon(icon2 , Player.gethero_by_group(2))
        set_icon(icon3 , Player.gethero_by_group(3))
        set_icon(icon4 , Player.gethero_by_group(4))
        set_icon(icon5 , Player.gethero_by_group(5))

        local card1 = ui_main_obj.transform:Find("icon/card1")
        local card2 = ui_main_obj.transform:Find("icon/card2")
        local card3 = ui_main_obj.transform:Find("icon/card3")
        local card4 = ui_main_obj.transform:Find("icon/card4")
        local card5 = ui_main_obj.transform:Find("icon/card5")

        set_card( card1 , Player.gethero_by_group(1) )
        set_card( card2 , Player.gethero_by_group(2) )
        set_card( card3 , Player.gethero_by_group(3) )
        set_card( card4 , Player.gethero_by_group(4) )
        set_card( card5 , Player.gethero_by_group(5) )

        local property1 = ui_main_obj.transform:Find("icon/property1")
        local property2 = ui_main_obj.transform:Find("icon/property2")
        local property3 = ui_main_obj.transform:Find("icon/property3")
        local property4 = ui_main_obj.transform:Find("icon/property4")
        local property5 = ui_main_obj.transform:Find("icon/property5")

        set_property(property1 , Player.gethero_by_group(1))
        set_property(property2 , Player.gethero_by_group(2))
        set_property(property3 , Player.gethero_by_group(3))
        set_property(property4 , Player.gethero_by_group(4))
        set_property(property5 , Player.gethero_by_group(5))
    end

    local function regEvent()
        for i=1,5,1 do
            if Player.group[i] ~= nil then
                local btn = ui_main_obj.transform:Find("icon/btn"..i)
                local ev = UI_Event.Get(btn)
                ev.onClick = {"+=", function( eventData , go , args )
                    GameObject.Destroy(ui_main_obj)

                    ui_hero_detail.create( Player.gethero_by_group(i) , function()
                        ui_system_bottom.show()
                        createObj()
                        updateInfo()
                        regEvent()
                    end
                    )
                    ui_system_bottom.hiden()
                end
                }
            end
        end

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

        local btn_quest1 = ui_main_obj.transform:Find("quest/quest1")
        local btn_quest2 = ui_main_obj.transform:Find("quest/quest2")
        local btn_quest3 = ui_main_obj.transform:Find("quest/quest3")
        
        ev = UI_Event.Get(btn_quest1)
        ev.onClick = { "+=" , function( eventData , go , args )
            print("quest1 click")
            GameObject.Destroy(ui_main_obj)
            local ui_quest = require("GUI/ui_quest")
            ui_quest.create()
        end
        }
        
        ev = UI_Event.Get(btn_quest2)
        ev.onClick = { "+=" , function( eventData , go , args )
            print("quest2 click")
            GameObject.Destroy(ui_main_obj)
            local ui_quest = require("GUI/ui_quest")
            ui_quest.create()
        end
        }

        ev = UI_Event.Get(btn_quest3)
        ev.onClick = { "+=" , function( eventData , go , args )
            print("quest3 click")
            GameObject.Destroy(ui_main_obj)
            local ui_quest = require("GUI/ui_quest")
            ui_quest.create()
        end
        }
    end

    createObj()
    updateInfo()
    regEvent()
end


local t = {}
t.create = create
return t

