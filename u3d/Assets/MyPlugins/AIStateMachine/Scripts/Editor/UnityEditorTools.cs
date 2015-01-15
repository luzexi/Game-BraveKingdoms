#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;

public static class UnityEditorTools
{
	/// <summary>
	/// Gets the names of the scenes, added to the build settings.
	/// </summary>
	public static string[] BuildScenes {
		get {
			List<string> temp = new List<string> ();
			foreach (UnityEditor.EditorBuildSettingsScene s in UnityEditor.EditorBuildSettings.scenes) {
				if (s.enabled) {
					string name = s.path.Substring (s.path.LastIndexOf ('/') + 1);
					name = name.Substring (0, name.Length - 6);
					temp.Add (name);
				}
			}
			return temp.ToArray ();
		}
	}

	/// <summary>
	/// Gets the name of the current loaded scene.
	/// </summary>
	public static string CurrentScene {
		get {
			string currentLoadedScene = string.Empty;
			currentLoadedScene = EditorApplication.currentScene.Substring (EditorApplication.currentScene.LastIndexOf ('/') + 1);
			currentLoadedScene = currentLoadedScene.Substring (0, currentLoadedScene.Length - 6);
			return currentLoadedScene;
		}
	}
	
	/// <summary>
	/// Draws all properties
	/// </summary>
	public static void DrawSerializedProperties(SerializedObject obj){
		SerializedProperty prop= obj.GetIterator();

		//Hide the script property
		prop.NextVisible(true);
		
		while (prop.NextVisible(true)){
			EditorGUILayout.PropertyField(prop);
		}
		obj.ApplyModifiedProperties();
	}

	public static void DrawSerializedProperties(SerializedProperty prop){
		//Hide the script property
		//prop.NextVisible(true);
		
		while (prop.NextVisible(true)){
			EditorGUILayout.PropertyField(prop);
		}
		prop.serializedObject.ApplyModifiedProperties();
	}
	
	public static string SearchField(string search, out bool changed, params GUILayoutOption[] options){
		GUILayout.BeginHorizontal ();
		string before = search;
		string after = EditorGUILayout.TextField ("", before, "SearchTextField");
		
		if (GUILayout.Button ("", "SearchCancelButton", GUILayout.Width (18f))) {
			after = string.Empty;
			GUIUtility.keyboardControl = 0;
		}
		GUILayout.EndHorizontal();
		
		changed= before != after;
		
		return after;
	}
	
	public static string StringPopup(Rect position, string value, string[] list){
		int index=0;
		if(list != null && list.Length>0){
			for(int cnt=0; cnt<list.Length;cnt++){
				if(value == list[cnt]){
					index=cnt;
				}
			}
			index=EditorGUI.Popup(position,index,list);
			return list[index];
		}
		return string.Empty;
	}
	
	public static string StringPopup(Rect position,string label, string value, string[] list){
		int index=0;
		if(list != null && list.Length>0){
			for(int cnt=0; cnt<list.Length;cnt++){
				if(value == list[cnt]){
					index=cnt;
				}
			}
			index=EditorGUI.Popup(position,label,index,list);
			return list[index];
		}
		return string.Empty;
	}
	
	public static string StringPopup(string value, string[] list,params GUILayoutOption[] options){
		return StringPopup ("", value, list,options);
	}
	
	public static string StringPopup(string label,string value, string[] list,params GUILayoutOption[] options){
		int index=0;
		if(list != null && list.Length>0){
			for(int cnt=0; cnt<list.Length;cnt++){
				if(value == list[cnt]){
					index=cnt;
				}
			}
		index=string.IsNullOrEmpty(label)?EditorGUILayout.Popup(index,list,options):EditorGUILayout.Popup(label,index,list,options);
			return list[index];
		}
		return string.Empty;
	}

	public static string StringPopup(GUIContent content,string value, string[] list,params GUILayoutOption[] options){
		int index=0;
		GUIContent[] contentItems=new GUIContent[list.Length];
		if(list != null && list.Length>0){
			for(int cnt=0; cnt<list.Length;cnt++){
				contentItems[cnt]= new GUIContent(list[cnt]);
				if(value == list[cnt]){
					index=cnt;
				}
			}


			index=EditorGUILayout.Popup(content,index,contentItems,options);
			return list[index];
		}
		return string.Empty;
	}

	public static string StringPopup(GUIContent content,string value,string postfix, string[] list,params GUILayoutOption[] options){
		int index=0;
		GUIContent[] contentItems=new GUIContent[list.Length];
		if(list != null && list.Length>0){
			for(int cnt=0; cnt<list.Length;cnt++){
				contentItems[cnt]= new GUIContent(list[cnt]+ postfix);
				if(value == list[cnt]){
					index=cnt;
				}
			}
			index=EditorGUILayout.Popup(content,index,contentItems,options);
			string val=list[index];
			if(!string.IsNullOrEmpty(postfix)){
				val=list[index].Replace(postfix,"");
			}
			return val;
		}
		return string.Empty;
	}

	/// <summary>
	/// Used to get assets of a certain type and file extension from entire project
	/// </summary>
	/// <param name="type">The type to retrieve. eg typeof(GameObject).</param>
	/// <param name="fileExtension">The file extention the type uses eg ".prefab".</param>
	/// <returns>An Object array of assets.</returns>
	public static T[] GetAssetsOfType<T>(string fileExtension) where T : UnityEngine.Object
	{
		List<T> tempObjects = new List<T>();
		System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(Application.dataPath);
		System.IO.FileInfo[] goFileInfo = directory.GetFiles("*" + fileExtension, System.IO.SearchOption.AllDirectories);
		
		int i = 0; int goFileInfoLength = goFileInfo.Length;
		System.IO.FileInfo tempGoFileInfo; string tempFilePath;
		T tempGO;
		for (; i < goFileInfoLength; i++)
		{
			tempGoFileInfo = goFileInfo[i];
			if (tempGoFileInfo == null)
				continue;
			
			tempFilePath = tempGoFileInfo.FullName;
			tempFilePath = tempFilePath.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
			tempGO = AssetDatabase.LoadAssetAtPath(tempFilePath, typeof(T)) as T;
			if (tempGO == null)
			{
				continue;
			}
			else if (!(tempGO is T))
			{
				continue;
			}
			
			tempObjects.Add(tempGO);
		}
		
		return tempObjects.ToArray();
	}

	public static Rect ScaleSizeBy(this Rect rect, float scale)
	{
		return rect.ScaleSizeBy(scale, rect.center);
	}
	
	public static Rect ScaleSizeBy(this Rect rect, float scale, Vector2 pivotPoint)
	{
		Rect rect1 = rect;
		rect1.x = rect1.x - pivotPoint.x;
		rect1.y = rect1.y - pivotPoint.y;
		rect1.xMin = rect1.xMin * scale;
		rect1.xMax = rect1.xMax * scale;
		rect1.yMin = rect1.yMin * scale;
		rect1.yMax = rect1.yMax * scale;
		rect1.x = rect1.x + pivotPoint.x;
		rect1.y = rect1.y + pivotPoint.y;
		return rect1;
	}
	
	public static Rect ScaleSizeBy(this Rect rect, Vector2 scale)
	{
		return rect.ScaleSizeBy(scale, rect.center);
	}
	
	public static Rect ScaleSizeBy(this Rect rect, Vector2 scale, Vector2 pivotPoint)
	{
		Rect rect1 = rect;
		rect1.x = rect1.x - pivotPoint.x;
		rect1.y = rect1.y - pivotPoint.y;
		rect1.xMin = rect1.xMin * scale.x;
		rect1.xMax = rect1.xMax * scale.x;
		rect1.yMin = rect1.yMin * scale.y;
		rect1.yMax = rect1.yMax * scale.y;
		rect1.x = rect1.x + pivotPoint.x;
		rect1.y = rect1.y + pivotPoint.y;
		return rect1;
	}
	
	public static Vector2 TopLeft(this Rect rect)
	{
		return new Vector2(rect.xMin, rect.yMin);
	}
}
#endif