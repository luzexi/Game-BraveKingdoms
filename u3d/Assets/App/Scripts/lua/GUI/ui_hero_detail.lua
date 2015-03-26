
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3

local function create( hero , func )
    local main_obj = nil
    local ui_name = "ui_hero_detail"

    local function createObj()
        main_obj = GameObject.Instantiate( Resources.Load("GUI/ui_hero_detail") )
        main_obj.name = ui_name
        main_obj.transform:SetParent(UI_Root)
        main_obj.transform.localPosition = Vector3.zero
        main_obj.transform.localScale = Vector3.one
    end

    local function updateInfo()
        local heroImg = main_obj.transform:Find("heroImg"):GetComponent("RawImage")
        local cost = main_obj.transform:Find("heroData/cost/Text"):GetComponent("Text")
        local attack = main_obj.transform:Find("heroData/attack/Text"):GetComponent("Text")
        local defence = main_obj.transform:Find("heroData/defence/Text"):GetComponent("Text")
        local equip = main_obj.transform:Find("heroData/equip/Text"):GetComponent("Text")
        local hp = main_obj.transform:Find("heroData/hp/Text"):GetComponent("Text")
        local lv_up = main_obj.transform:Find("heroData/lv_up/Text"):GetComponent("Text")
        local lv = main_obj.transform:Find("heroData/lv/Text"):GetComponent("Text")
        local recover = main_obj.transform:Find("heroData/recover/Text"):GetComponent("Text")
        local hero_type = main_obj.transform:Find("heroData/type/Text"):GetComponent("Text")
        local star = main_obj.transform:Find("heroData/star")
        local exp = main_obj.transform:Find("heroData/exp/exp_bar")
        local lock = main_obj.transform:Find("heroData/lock")

        local table = datatable.getTable("Hero")[hero.tableid]
        heroImg.texture = Resources.Load("AvatarA/"..table.AvatarA)
        cost.text = ""..table.Cost
        attack.text = ""..hero.attack
        defence.text = ""..hero.defence
        equip.text = "ToDo"
        hp.text = ""..hero.maxhp
        lv_up.text = "ToDo"
        lv.text = ""..hero.lv
        recover.text = ""..hero.recover
        if table.Type == 0 then
            hero_type.text = "英雄"
        elseif table.Type == 1 then
            hero_type.text = "经验素材"
        elseif table.Type == 2 then
            hero_type.text = "进化素材"
        elseif table.Type == 3 then
            hero_type.text = "金钱素材"
        end
        
        if hero.lock then
            lock.gameObject:SetActive(true)
        else
            lock.gameObject:SetActive(false)
        end
        local star1 = star:Find("star1")
        local star2 = star:Find("star2")
        local star3 = star:Find("star3")
        local star4 = star:Find("star4")
        local star5 = star:Find("star5")
        local strlst = {star1 , star2 , star3 , star4 , star5}
        for i = table.StarLevel+1, 5 , 1 do
            strlst[i].gameObject:SetActive(false)
        end
    end

    local function regEvent()
        local collider = main_obj.transform:Find("collider")
        local ev = UI_Event.Get(collider)
        ev.onClick = {"+=",function(eventData , go , args)
            GameObject.Destroy(main_obj)
            func()
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
