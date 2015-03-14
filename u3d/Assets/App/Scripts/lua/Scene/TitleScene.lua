
local ui_title = require("GUI/ui_title")
local save_data = require "Manager/SaveData"


local function create()
    ui_title.create()
end


local t = {}
t.create = create
return t

