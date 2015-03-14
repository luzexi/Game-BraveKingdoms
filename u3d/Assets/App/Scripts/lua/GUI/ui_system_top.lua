
local GameObject = UnityEngine.GameObject
local Resources = UnityEngine.Resources
local Vector3 = UnityEngine.Vector3


local UI_Name = "ui_system_top"


local function create( )
    local obj = UI_SystemRoot:Find(UI_Name)
    if obj ~= nil then
        return obj.gameObject
    end
    local main = GameObject.Instantiate( Resources.Load("GUI/ui_system_top") )
    main.name = UI_Name
    main.transform:SetParent( UI_SystemRoot )
    main.transform.localPosition = Vector3.zero
    main.transform.localScale = Vector3.one

    local function updateInfo()
        local gold = main.transform:Find("background/gold/text"):GetComponent("Text")
        gold.text = Player.gold
        local soul = main.transform:Find("background/soul/text"):GetComponent("Text")
        soul.text = Player.soul
        local crystal = main.transform:Find("background/crystal/text"):GetComponent("Text")
        crystal.text = Player.crystal
        local bstar = main.transform:Find("background/bstar/text"):GetComponent("Text")
        bstar.text = Player.bstar
        local hp = main.transform:Find("background/hp/bar"):GetComponent("Scrollbar")
        hp.size = Player.hp / Player.maxhp
        local exp = main.transform:Find("background/exp"):GetComponent("Scrollbar")
        exp.size = Player.exp / Player.maxexp
    end
    updateInfo()
    return main
end

-- show ui
local function show()
    local obj = create()
    obj:SetActive(true)
end


-- hiden ui
local function hiden()
    local obj = UI_SystemRoot:Find(UI_Name)
    if obj ~= nil then
        obj.gameObject:SetActive(false)
    end
end


local t = {}
t.show = show
t.hiden = hiden
return t
