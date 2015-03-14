
local player = require "Data/Player"
local hero = require "Data/Hero"
local PlayerPrefs = UnityEngine.PlayerPrefs
local json = require "lib/dkjson"

-- define save data const string
local CONST_PLAYER_DATA = "player_data"
local CONST_HERO_INDEX = "hero_index"
local CONST_ITEM_INDEX = "item_index"



local function start()
    HERO_GENERATE_INDEX = PlayerPrefs.GetInt( CONST_HERO_INDEX , 0 )
    ITEM_GENERATE_INDEX = PlayerPrefs.GetInt( CONST_ITEM_INDEX , 0 )

    local player_data = PlayerPrefs.GetString( CONST_PLAYER_DATA , "" )
    if string.len(player_data) <= 0 then
        player.init()
    else
        Player = json.decode(player_data)
    end

end

local function set_str( key , value )
    PlayerPrefs.SetString( key , value )
end

local function save()
    PlayerPrefs.SetInt( CONST_HERO_INDEX , HERO_GENERATE_INDEX )
    PlayerPrefs.SetInt( CONST_ITEM_INDEX , ITEM_GENERATE_INDEX )

    local player_data = json.encode(Player,{indent=false})
    print("save data player " .. player_data)
    PlayerPrefs.SetString( CONST_PLAYER_DATA , player_data)
end



local t = {}
t.start = start
t.set = set
t.save = save
return t
