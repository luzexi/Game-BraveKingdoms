
local ui_title = require("GUI/UITitle")

print("ok in title scene")


local function start()
    print("ok in the title scene lua.");
    ui_title.show()
end


local t = {}
t.start = start
return t

