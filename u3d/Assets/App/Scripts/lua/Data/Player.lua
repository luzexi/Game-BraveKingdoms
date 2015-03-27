
local hero = require "Data/Hero"



local function init()
    Player = {}
    Player.Name = "Jesse"
    Player.level = 1
    Player.exp = 0
    Player.maxexp = 100
    Player.gold =9999
    Player.soul = 9898
    Player.crystal = 341
    Player.bstar = 3233
    Player.hp = 100
    Player.maxhp = 100
    Player.leaderid = 0
    Player.items = {}
    Player.heros = {}
    Player.group = {}
    Player.mails = {}

    -- create hero
    local tmpHero1 = hero.create(11)
    table.insert( Player.heros ,#Player.heros + 1, tmpHero1)
    local tmpHero2 = hero.create(20)
    table.insert( Player.heros ,#Player.heros + 1, tmpHero2)
    local tmpHero3 = hero.create(13)
    table.insert( Player.heros ,#Player.heros + 1, tmpHero3)
    local tmpHero4 = hero.create(40)
    table.insert( Player.heros ,#Player.heros + 1, tmpHero4)
    local tmpHero5 = hero.create(195)
    table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    --
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(77)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(77)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(77)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(77)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(77)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(66)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(66)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(66)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(66)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(66)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(99)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)

    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    -- tmpHero5 = hero.create(195)
    -- table.insert( Player.heros ,#Player.heros + 1, tmpHero5)
    
    --

    -- create group
    Player.group = { tmpHero1.id , tmpHero2.id , tmpHero3.id , tmpHero4.id , tmpHero5.id }
    Player.leaderid = tmpHero2.id
    Player.gethero_by_group = function( index )
        local id = Player.group[index]
        local i
        for i = 1 , #Player.heros , 1 do
            if Player.heros[i].id == id then
                return Player.heros[i]
            end
        end
        return nil
    end
    Player.getgroup_hero = function()
        local grouphero = {}
        local i = 1
        for i = 1 , #Player.group ,1 do
            local hero = -1
            if Player.group[i] > 0 then
                hero = Player.gethero_by_group(i)
            end
            table.insert(grouphero , #grouphero+1 , hero)
        end
        return grouphero
    end
    -- for i=0,4,1 do
    --     local group = { tmpHero1 , tmpHero2 , tmpHero3 , tmpHero4 , tmpHero5 }
    --     Player.groups[i] = group
    -- end
end



local t = {}
t.init = init
return t