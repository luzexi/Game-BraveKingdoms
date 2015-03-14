

local function create( tableid )
    ITEM_GENERATE_INDEX =  ITEM_GENERATE_INDEX + 1
    local item = {}
    item.id = ITEM_GENERATE_INDEX
    item.tableid = tableid
    item.num = 0
    return item
end

local t = {}
t.create = create
return t
