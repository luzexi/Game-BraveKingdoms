
local Resources = UnityEngine.Resources
local TextAsset = UnityEngine.TextAsset
local json = require "lib/dkjson"


local function create()
    if HeroTable ~= nil then
        return
    end
    local at = Resources.Load("Data/Table_Hero")
    local str = at.text
    HeroTable = {}
    local tmptable = json.decode(str)

    for key , val in pairs(tmptable) do
        HeroTable[val.id] = val
        -- HeroTable[""..val.id] = val
    end

    -- print(HeroTable[""..1]["Name"])
end

local t = {}
t.create = create
return t
