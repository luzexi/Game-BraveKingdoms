
print("This is a script from a file")

local ts = require "Scene/TitleScene"
-- local ts = dofile("Scene/TitleScene")

-- local ts = require "Scene/TitleScene"
-- print("This is a script from a file 世界")

local function main()
    print("ok , in the main lua")
    ts:start()
end

t = {}
t.main = main
return t