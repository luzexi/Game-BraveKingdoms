
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
    HeroTable = json.decode(str)

    -- print(HeroTable[""..1]["Name"])
end

local t = {}
t.create = create
return t
