
python ../Tool/xls2lua/xls2lua.py TABLE_英雄.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_物品.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_抽卡1.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_关卡.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_技能.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_英雄攻击.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_英雄成长表.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_英雄经验表.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_角色经验及成长.xlsx ../Data/
python ../Tool/xls2lua/xls2lua.py TABLE_物品合成表.xlsx ../Data/


# source ./enemy.sh


for FILE in ./Enemy/TABLE_Enemy*
do
	echo $FILE
	# echo 'python ../Tool/xls2lua/xls2lua.py $FILE ../Data/Enemy/'
done


cp -r ../Data ../u3d/Assets/App/Scripts/lua/DataTable
