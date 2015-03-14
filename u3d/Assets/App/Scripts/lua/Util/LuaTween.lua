


TweenUtil = {}

function TweenUtil.MoveTo()
end



function import(name)
    local t = _G[name]
    if t == nil then
        return nil
    end
    for k,v in pairs(t) do
        _G[k] = v
    end
end
