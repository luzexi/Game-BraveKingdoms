using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.IO;

namespace StateMachine{
	public static class CreateCondition{
		[MenuItem("Assets/Create/State Machine/Script/Condition")]
		public static void CreateConditionScript(){
			string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
			if (assetPath == "")
			{
				assetPath = "Assets";
			}
			else if (Path.GetExtension(assetPath) != "")
			{
				assetPath = assetPath.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
			}
			string str = AssetDatabase.GenerateUniqueAssetPath(string.Concat(assetPath, "/", "NewCondition", ".cs"));
			StreamWriter streamWriter = new StreamWriter(str, false);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
			streamWriter.Write(string.Concat("using UnityEngine;\n\nnamespace StateMachine.Condition{\n\t[Info (category = \"Category\",\n\tdescription = \"Description\", \n\turl = \"Link\")]\n\tpublic class ", fileNameWithoutExtension, " : StateCondition\n\t{\n\t\tpublic override void OnEnter()\n\t\t{\n\t\t\n\t\t}\n\n\t\tpublic override bool Validate()\n\t\t{\n\t\t\treturn true;\n\t\t}\n\t}\n}"));
			streamWriter.Close();
			AssetDatabase.Refresh();		
		}
	}
}