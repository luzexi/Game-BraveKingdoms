local Network = Network;


lua_http = {}

function lua_http.request( url , fun_callback )
    local callback = LuaUtil.ToActionStr(fun_callback)
    if callback == nil then
        print("callback is nil.")
    end
    Network.Request(url , "" , callback)
end

return lua_http

