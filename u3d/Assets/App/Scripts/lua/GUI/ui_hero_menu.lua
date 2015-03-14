
local GameObject = UnityEngine.GameObject
local Vector3 = UnityEngine.Vector3
local Resources = UnityEngine.Resources


local function create()
    local ui_main = require "GUI/ui_main"

    local main_obj = nil
    local ui_name = "ui_hero_menu"

    local function createObj()
        main_obj = GameObject.Instantiate(Resources.Load("GUI/ui_hero_menu"))
        main_obj.name = ui_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
        UI_Master = main_obj
    end

    local function regEvent()
        local btn_back = main_obj.transform:Find("btn_back")
        local ev = UI_Event.Get(btn_back)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            ui_main.create()
        end
        }

        local btn_hero_lst = main_obj.transform:Find("btn_heros")
        ev = UI_Event.Get(btn_hero_lst)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            ui_hero_list = require("GUI/ui_hero_list")
            ui_hero_list.create()
        end
        }

        local btn_hero_sell = main_obj.transform:Find("btn_sell")
        ev = UI_Event.Get(btn_hero_sell)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            ui_hero_sell = require("GUI/ui_hero_sell")
            ui_hero_sell.create()
        end
        }

        local btn_evolution = main_obj.transform:Find("btn_evolution")
        ev = UI_Event.Get(btn_evolution)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            ui_hero_evolution = require("GUI/ui_hero_evolution")
            ui_hero_evolution.create()
        end
        }

        local btn_team_editor = main_obj.transform:Find("btn_team_editor")
        ev = UI_Event.Get(btn_team_editor)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            ui_hero_team = require("GUI/ui_hero_team")
            ui_hero_team.create()
        end
        }

        local btn_combine = main_obj.transform:Find("btn_combine")
        ev = UI_Event.Get(btn_combine)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            ui_hero_combine = require("GUI/ui_hero_combine")
            ui_hero_combine.create()
        end
        }

        local btn_equip = main_obj.transform:Find("btn_equip")
        ev = UI_Event.Get(btn_equip)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            ui_hero_equip = require("GUI/ui_hero_equip")
            ui_hero_equip.create()
        end
        }
    end

    createObj()
    regEvent()
end


local t = {}
t.create = create
return t

