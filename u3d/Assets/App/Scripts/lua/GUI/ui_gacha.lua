

local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3
local Screen = UnityEngine.Screen


local gacha1_table = datatable.getTable("Gacha1")

local function create()
    local ui_main = require "GUI/ui_main"
    local ui_system_bottom = require("GUI/ui_system_bottom")

    local main_obj = nil
    local ui_name = "ui_gacha"
    local ratex = SCREEN_WIDE/Screen.width

    local function createObj()
        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_gacha"))
        main_obj.name = ui_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
        ui_system_bottom.show()
        UI_Master = main_obj
    end

    local function regEvent()
        local btn_left = main_obj.transform:Find("arrowLeft")
        local ev = UI_Event.Get(btn_left)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("ok in btn left")
        end
        }
        local btn_right = main_obj.transform:Find("arrowRight")
        ev = UI_Event.Get(btn_right)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("ok in btn right")
        end
        }


        local function gacha_low()
            local sum_weight = 0
            for k,v in pairs(gacha1_table) do
                sum_weight = sum_weight + v.weight
            end
            local pertable = {}
            for k,v in pairs(gacha1_table) do
                table.insert( pertable , #pertable + 1, { id=v.id , per=v.weight/sum_weight} )
            end
            math.randomseed(os.time())
            local randomPer = math.random()
            local randomIndex = math.random(0 , #pertable-1)
            local i = 0
            local tmpSum = 0
            local result = 0
            for i = 1 , #pertable , 1 do
                tmpSum = tmpSum + pertable[randomIndex+1].per
                if tmpSum >= randomPer then
                    result = i
                    break
                end
                randomIndex = (randomIndex+1)%(#pertable)
            end

            local hero_lua = require("Data/Hero")
            local hero = hero_lua.create( pertable[result].id )
            table.insert(Player.heros , #Player.heros + 1 , hero)
            GameObject.Destroy(main_obj)
            local ui_hero_detail = require("GUI/ui_hero_detail")
            ui_system_bottom.hiden()
            ui_hero_detail.create(hero , create)
        end

        local gacha1_btn = main_obj.transform:Find("btn_gacha1/btn")
        local gacha2_btn = main_obj.transform:Find("btn_gacha2/btn")
        local gacha_super1_btn = main_obj.transform:Find("btn_gacha_super1/btn")
        local gacha_super2_btn = main_obj.transform:Find("btn_gacha_super2/btn")
        ev = UI_Event.Get(gacha1_btn)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("xxx gacha1 btn")
            gacha_low()
        end
        }
        ev = UI_Event.Get(gacha2_btn)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("xxx gacha2 btn")
            gacha_low()
        end
        }
        ev = UI_Event.Get(gacha_super1_btn)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("gacha_super1_btn btn")
            gacha_low()
        end
        }
        ev = UI_Event.Get(gacha_super2_btn)
        ev.onClick = {"+=" , function(eventData , go , args)
            print("gacha_super2_btn btn")
            gacha_low()
        end
        }

    end

    createObj()
    regEvent()
end


local t = {}
t.create = create
return t

