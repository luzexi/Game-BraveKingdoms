﻿local Network = Network;


lua_http = {}

function lua_http.request( url , fun_callback )
    local callback = LuaUtil.ToActionStr(fun_callback)
    if callback == nil then
        print("callback is nil.")
    end
    Network.Request(url , "" , callback)
end

-- function lua_http.request( url , arg , fun_callback )
--     -- body
-- end



-- local function create()
--     local arg_table = {}
--     local function dispatcher (...)
--         local tbl = arg_table
--         local n = select ("#",...)
--         local last_match
--         for i = 1,n do
--             local t = type(select(i,...))
--             local n = tbl[t]
--             last_match = tbl["..."] or last_match
--             if not n then
--                 return last_match (...)
--             end
--             tbl = n
--         end
--         return (tbl["__end"] or tbl["..."])(...)
--     end
--     local function register(desc,func)
--         local tbl = arg_table
--         for _,v in ipairs(desc) do
--             if v=="..." then
--                 assert(not tbl["..."])
--                 tbl["..."] = func
--                 return
--             end
 
--             local n = tbl[v]
--             if not n then
--                 n = {}
--                 tbl[v]=n
--             end
--             tbl = n
--         end
--         tbl["__end"] = func
--     end
--     return dispatcher, register, arg_table
-- end
 
-- local all={}
 
-- local function register(env,desc,name)
--     local func = desc[#desc]
--     assert(type(func)=="function")
--     desc[#desc] = nil
 
--     local func_table
--     if all[env] then
--         func_table = all[env]
--     else
--         func_table = {}
--         all[env] = func_table
--     end
 
--     if env[name] then
--         assert(func_table[name])
--     else
--         env[name],func_table[name] = create()
--     end
 
--     func_table[name](desc,func)
-- end
 
-- lua_http = setmetatable({},{
--     __index = function (t,k)
--         local function reg (desc)
--             register(getfenv(2),desc,k)
--         end
--         t[k] = reg
--         return reg
--     end
-- })

return lua_http

