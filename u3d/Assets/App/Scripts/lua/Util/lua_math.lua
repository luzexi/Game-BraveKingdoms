




-- local function RANDOM_BET( num, perLst )
-- {
--     if (perLst == nil or num <= 0)
--         return nil;
--     local i , j ,k = 0

--     local typeNum = #perLst;
--     local selectPos = {};
--     local vecRandom = {};

--     for i = 0 , num , 1 do
--         selectPos[i] = -1;
--         vecRandom[i] = RANDOM_ONE();
--     end

--     for i = 0 , num , 1 do
--         sumPos = 0;
--         local j = RANDOM(0,typeNum)
--         for k = 0 , #perLst , 1 do
--         {
--             sumPos = sumPos + perLst[j % typeNum];
--             if (sumPos >= vecRandom[i])
--             {
--                 selectPos[i] = j % typeNum;
--                 break;
--             }
--         }
--     end

--     return selectPos;
-- }


-- local t = {}
-- t.create = create
-- return t

