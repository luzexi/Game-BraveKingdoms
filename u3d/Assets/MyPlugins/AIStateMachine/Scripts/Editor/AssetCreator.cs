using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;

namespace StateMachine{
	public static class AssetCreator {
		/// <summary>
		/// Creates a custom asset
		/// </summary>
		public static T CreateAsset<T> (bool displayFilePanel) where T : ScriptableObject
		{
			if (displayFilePanel) {
				T asset = null;
				string mPath = EditorUtility.SaveFilePanelInProject (
					"Create Asset of type " + typeof(T).ToString (),
					"New " + typeof(T).ToString () + ".asset",
					"asset", "");
				
				asset = CreateAsset<T> (mPath);
				return asset;
			}
			return CreateAsset<T> ();
		}
		
		/// <summary>
		/// Creates a custom asset at selected Object
		/// </summary>
		public static T CreateAsset<T> () where T : ScriptableObject
		{
			T asset = null;
			string path = AssetDatabase.GetAssetPath (Selection.activeObject);
			
			if (path == "") {
				path = "Assets";
			} else if (System.IO.Path.GetExtension (path) != "") {
				path = path.Replace (System.IO.Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
			}
			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/New " + typeof(T).ToString ().Split('.').Last() + ".asset");
			asset = CreateAsset<T> (assetPathAndName);
			return asset;
		}
		
		/// <summary>
		/// Creates a custom asset at path
		/// </summary>
		public static T CreateAsset<T> (string path) where T : ScriptableObject
		{
			if (string.IsNullOrEmpty (path)) {
				return null;
			}
			T data = null;
			data = ScriptableObject.CreateInstance<T> ();
			AssetDatabase.CreateAsset (data, path);
			AssetDatabase.SaveAssets ();
			return data;
		}
	}
}