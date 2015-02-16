
print("Start. Let's go.")


local ui_manager = require "Manager.UIManager"
local game_define = require "Manager.GameDefine"
local title_scene = require "Scene/TitleScene"


function main()
    ui_manager.create()
    game_define.create()
    title_scene.create()
end

