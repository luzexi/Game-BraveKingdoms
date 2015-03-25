
for FILE in ./Enemy/TABLE_Enemy*
do
	`python ../Tool/excelAndJSON/src/excel_and_json.py singlebook -o ../Data/Enemy/ -i ${FILE}`
done
