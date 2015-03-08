


local Resources = UnityEngine.Resources
local TextAsset = UnityEngine.TextAsset
local json = require "lib/dkjson"


local function create()
    if Gacha1Table ~= nil then
        return
    end
    local at = Resources.Load("Data/Table_Gacha1")
    local str = at.text
    Gacha1Table = {}
    Gacha1Table = json.decode(str)
end


local t = {}
t.create = create
return t


