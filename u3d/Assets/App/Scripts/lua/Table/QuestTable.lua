
local Resources = UnityEngine.Resources
local TextAsset = UnityEngine.TextAsset
local json = require "lib/dkjson"


local function create()
    if QuestTable ~= nil then
        return
    end
    local at = Resources.Load("Data/Table_Quest")
    local str = at.text
    QuestTable = {}
    local json_data = json.decode(str)
    local i = 1

    while(true)
    do
        local tmp_data = json_data[""..i]
        if tmp_data ~= nil then
            table.insert(QuestTable , #QuestTable+1 , tmp_data)
        else
            break
        end
        i = i+1
    end

    -- print(QuestTable[""..1]["Name"])
end

local t = {}
t.create = create
return t
