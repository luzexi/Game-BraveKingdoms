local save_data = require "Manager/SaveData"
local table_manager = require "Manager/TableManager"
local ui_system_bottom = require "GUI/ui_system_bottom"
local ui_system_top = require "GUI/ui_system_top"
local ui_main = require "GUI/ui_main"


-- create
local function create()
    -- create table and save data
    table_manager.create()
    save_data.start()

    -- show ui system
    ui_system_bottom.show()
    ui_system_top.show()

    -- ui main
    ui_main.create()
end


local t = {}
t.create = create
return t

