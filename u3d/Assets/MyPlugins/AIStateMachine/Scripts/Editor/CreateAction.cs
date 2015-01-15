using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.IO;

namespace StateMachine{
	public static class CreateAction {
		[MenuItem("Assets/Create/State Machine/Script/Action")]
		public static void CreateActionScript(){
			string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
			if (assetPath == "")
			{
				assetPath = "Assets";
			}
			else if (Path.GetExtension(assetPath) != "")
			{
				assetPath = assetPath.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
			}
			string str = AssetDatabase.GenerateUniqueAssetPath(string.Concat(assetPath, "/", "NewAction", ".cs"));
			StreamWriter streamWriter = new StreamWriter(str, false);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
			streamWriter.Write(string.Concat("using UnityEngine;\n\nnamespace StateMachine.Action{\n\t[Info (category = \"Category\",\n\tdescription = \"Description\", \n\turl = \"Link\")]\n\tpublic class ", fileNameWithoutExtension, " : StateAction\n\t{\n\t\tpublic override void OnEnter()\n\t\t{\n\t\t\n\t\t}\n\n\t\tpublic override void OnUpdate()\n\t\t{\n\t\t\n\t\t}\n\t}\n}"));
			streamWriter.Close();
			AssetDatabase.Refresh();		
		}
	}
}