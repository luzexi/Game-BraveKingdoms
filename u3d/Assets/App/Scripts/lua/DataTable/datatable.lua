


datatable_cache = {}
datatable = {}

local function getTable( name )
    if datatable_cache[name] ~= nil then
        return datatable_cache[name]
    end
    local tmp_table = require("DataTable."..name)
    if tmp_table ~= nil then
        datatable_cache[name] = tmp_table
        return tmp_table
    end
    -- it may be load csv file in here
end


datatable.getTable = getTable


return datatable
