
local Resources = UnityEngine.Resources
local TextAsset = UnityEngine.TextAsset
local json = require "lib/dkjson"


local function create()
    if ItemTable ~= nil then
        return
    end
    local at = Resources.Load("Data/Table_Item")
    local str = at.text
    ItemTable = {}
    local tmptable = json.decode(str)

    for key , val in pairs(tmptable) do
        ItemTable[val.id] = val
    end
    -- print(ItemTable[""..1]["Name"])
end

local t = {}
t.create = create
return t
