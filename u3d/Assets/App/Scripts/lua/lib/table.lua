-- table.lua
-- tableを扱うライブラリ
-- arrayも追加する。
-- http://d.hatena.ne.jp/eiji8pou/20120110/1326129728
do
	array = {}

	-- テーブルのシンプルなコピー
	-- そのままコピーするので、値にテーブルがあったりしたらそれを参照渡ししてしまう。
	table.copy = function(t)
		local new = {}
		for k, v in pairs(t) do new[k] = v end
		return new
	end
	array.copy = table.copy
	
	-- テーブルのクローン
	-- 値がnumber, string, function等はそのまま代入。
	-- tableがあれば、それをさらにクローンする。
	table.clone = function(t)
		local new = {}
		for k, v in pairs(t) do
			if type(v) == "table" then
				new[k] = table.clone(v)
			else
				new[k] = v
			end
		end
		return new
	end
	array.clone = table.clone
	
	-- テーブルの移し替え
	-- テーブルaからテーブルbに中身を全部入れ替える。
	-- テーブル変数の実体は変更せずに、中身だけ変更したい時に有効。
	-- メタテーブルについてはさわっていないので、注意。
	-- fromには影響はない。
	table.move = function(from, to)
		for k, v in pairs(to)   do rawset(to, k, nil) end
		for k, v in pairs(from) do rawset(to, k, v  ) end
		return to
	end
	array.move = table.move

	-- ミックスソートで使う比較関数群
	local compare_box = {}
	compare_box.number = {}
	compare_box.number.number = function(a, b) return a<b end
	compare_box.number.string = function() return true end
	compare_box.string = {}
	compare_box.string.number = function() return false end
	compare_box.string.string = compare_box.number.number
	
	local compare = function(a, b)
		return compare_box[type(a)][type(b)](a, b)
	end
	
	-- ミックスソート。数値と文字列の入り混じった配列をソートする。
	-- 数値の後に文字列がきて、数値は数値同士、文字列は文字列同士並ぶ。
	array.mix_sort = function(t) table.sort(t, compare) end
	
	-- そのテーブルの持っているキーをテーブルの値にして返す。
	table.keys = function(t)
		local new = {}
		for k, v in pairs(t) do new[1+#new] = k end
		table.sort(new, compare)
		return new
	end
	array.keys = table.keys
	
	-- そのテーブルのnumber型キーのうち、最大値を返す。
	-- 間を飛ばした配列型テーブルに使うと有効。
	-- 文字列キーが混じっていても無視する。
	table.last = function(t)
		local max = 0
		for k, v in pairs(t) do
			if type(k)=="number" then
				if max<k then max=k end
			end
		end
		return max
	end
	array.last = table.last
	
	-- 配列の空いてる部分を指定した何かで埋める。
	array.fill = function(t, v)
		local max = array.last(t)
		if max==0 then return t end
		for i=1, max do
			if type(t[i])=="nil" then t[i] = v end
		end
		return t
	end
	
	-- 二分法
	-- 引数に関数を与え、
	-- 配列型テーブルの各要素を二つの配列型テーブルに分けて返す。順番は守られる。
	array.dichotomy = function(t, func)
		local res1 = {}
		local res2 = {}
		for i, v in ipairs(t) do
			if func(v) then res1[1+#res1] = v else res2[1+#res2] = v end
		end
		return res1, res2
	end
	
	-- テーブル版二分法
	-- 順番は守られない。
	table.dichotomy = function(t, func)
		local res1 = {}
		local res2 = {}
		for i, v in pairs(t) do
			if func(v) then res1[i] = v else res2[i] = v end
		end
		return res1, res2
	end

	-- フィルタリング
	array.filter = function(t, func)
		local res = array.dichotomy(t, func)
		return res
	end
	
	table.filter = function(t, func)
		local res = table.dichotomy(t, func)
		return res
	end

	-- ユニーク
	-- 配列変数に対して使う。重複する値があったら、二度目以降は削除してコピーを返す。
	array.unique = function(t)
		local check = {}
		local res = {}
		for i, v in ipairs(t) do
			if not(check[v]) then
				check[v] = true
				res[1+#res] = v
			end
		end
		return res
	end
	
	-- 複数の配列を接続する。
	-- 引数には複数の配列を与える。先頭の配列に、残りの全ての配列の全要素を足す。
	-- その後、先頭の配列を返す。
	-- 先頭の配列だけが影響を受け、他の配列は影響を受けない。
	array.join = function(...)
		local args = {...}
		local res = table.remove(args, 1) -- 先頭を取得
		for i, arg in ipairs(args) do
			if type(arg)=="table" then
				for k, v in ipairs(arg) do
					res[1+#res] = v
				end
			else
				res[1+#res] = arg
			end
		end
		return res
	end

	-- その配列の中からランダムに一つ抜き出して返す。
	-- table.removeを使っているので、抜いた分詰められる。
	-- 第二引数には関数を指定できる。指定できなければ、math.randomが使われる。
	-- 第二引数の関数は、math.randomに引数を一つ指定した場合と同様の動作が期待されている。
	array.pick = function(t, func)
		if 0==#t then return nil end
		func = func or math.random
		return table.remove(t, func(#t))
	end
	
	-- array.pickの連想配列版
	-- 返り値がk, vになっている点が違う。
	table.pick = function(t, func)
		local k = array.pick(table.keys(t), func)
		local v = t[k]
		t[k] = nil
		return k, v
	end
end
