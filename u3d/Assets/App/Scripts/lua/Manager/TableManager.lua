

local hero_table = require "Table/HeroTable"
local item_tabel = require "Table/ItemTable"


local function create()
    hero_table.create()
    item_tabel.create()
end



local t = {}
t.create = create
return t
