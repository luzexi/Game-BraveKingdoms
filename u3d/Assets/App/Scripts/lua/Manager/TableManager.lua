﻿

local hero_table = require "Table/HeroTable"
local item_tabel = require "Table/ItemTable"
local gacha1_table = require "Table/Gacha1Table"


local function create()
    hero_table.create()
    item_tabel.create()
    gacha1_table.create()
end



local t = {}
t.create = create
return t
