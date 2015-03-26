
print("Start. Let's go.")


local ui_manager = require "Manager.UIManager"
local game_define = require "Manager.GameDefine"
local title_scene = require "Scene/TitleScene"
local globa_manager = require "Manager.GlobalManager"


function main()
    ui_manager.create()
    game_define.create()
    title_scene.create()
    globa_manager.create()

    local hero_table = require("DataTable/Hero.lua")
    print(hero_table[220].AvatarM)
    print(hero_table[220].Desc)
end

