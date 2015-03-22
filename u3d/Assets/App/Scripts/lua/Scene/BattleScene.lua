



local function create()
    local ui_bg = require("GUI/ui_background")
    ui_bg.hiden()
    local ui_top = require("GUI/ui_system_top")
    ui_top.hiden()
    local ui_bottom = require("GUI/ui_system_bottom")
    ui_bottom.hiden()
    
    local ui_battle = require("GUI/ui_battle")
    ui_battle.create()
end



local t = {}
t.create = create
return t