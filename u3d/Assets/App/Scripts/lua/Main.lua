
print("Start. Let's go.")


local ui_manager = require "Manager.UIManager"
local title_scene = require "Scene/TitleScene"


function main()
    ui_manager.start()
    title_scene.create()
end

