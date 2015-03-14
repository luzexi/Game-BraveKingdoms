using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StateMachine{
	public class GlobalParameterEditor : EditorWindow {
		
		[MenuItem("Window/State Machine/Global Parameters", false, 2)]
		public static void ShowWindow()
		{
			GlobalParameterEditor window = EditorWindow.GetWindow<GlobalParameterEditor>(false, "Global Parameters");
			window.minSize = new Vector2(280f, 410f);
			window.wantsMouseMove = true;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}

		private string parameterName;
		private string parameterGroup="Default";
		private Type mType;
		private GlobalParameterCollection paramterCollection;
		private Vector2 scroll;
		private bool sceneReferenceFoldOut;


		private void OnGUI(){
			if (paramterCollection == null) {
				return;			
			}

			EditorGUILayout.HelpBox ("Global parameters can be accessed from all state machines.", MessageType.Info);
			EditorGUIUtility.labelWidth = 84;
			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Select Group",GUILayout.Width(80));
			if (GUILayout.Button (parameterGroup,EditorStyles.toolbarDropDown)) {
				GenericMenu menu= new GenericMenu();
				foreach(NamedParameter parameter in paramterCollection.parameters){
					string group=parameter.Group;
					menu.AddItem(new GUIContent(group),parameterGroup==group,delegate() {
						parameterGroup=group;
						paramterCollection.parameters.Sort((a, b) =>  a.Group.CompareTo(b.Group));
					});
				}
				menu.ShowAsContext();
			}
			parameterGroup=EditorGUILayout.TextField (parameterGroup);
			GUILayout.EndHorizontal ();

			parameterName = EditorGUILayout.TextField ("Name", parameterName);
			bool flag = !string.IsNullOrEmpty (parameterName);
			if (!flag) {
				EditorGUILayout.HelpBox("Please enter a unique name for the parameter before you continue.",MessageType.Warning);		
			}

			if (flag && paramterCollection != null) {
				if(paramterCollection.parameters == null){
					paramterCollection.parameters= new List<NamedParameter>();
				}
				foreach(NamedParameter mParamter in paramterCollection.parameters){
					if(mParamter != null && mParamter.Name == parameterName){
						flag=false;
					}
				}			
			}

			GUI.enabled = flag;
			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Type",GUILayout.Width(80));
			if (mType == null) {
				mType=typeof(BoolParameter);			
			}
			string typeString = mType.ToString ().Split ('.').Last ().Replace ("Parameter", "");
			if (GUILayout.Button (typeString,EditorStyles.toolbarDropDown)) {
				GenericMenu genericMenu = new GenericMenu ();
				IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies ().SelectMany (assembly => assembly.GetTypes ()) .Where (type => type.IsSubclassOf (typeof(NamedParameter)));
				foreach (Type type in types) {
					genericMenu.AddItem (new GUIContent (type.ToString ().Split ('.').Last ().Replace ("Parameter", "")), false, this.SelectParameterType, type);
					
				}
				genericMenu.ShowAsContext ();
			}

			if (GUILayout.Button ("Add", EditorStyles.toolbarButton,GUILayout.Width(70))) {
				CreateParameter();
			}
			GUILayout.Space (5);
			GUILayout.EndHorizontal ();
			GUILayout.Space (3);
			GUILayout.Box(GUIContent.none,"PopupCurveSwatchBackground",GUILayout.Height(2),GUILayout.ExpandWidth(true));

			if (paramterCollection != null) {
				if(!flag){
					GUI.enabled=true;
				}
				DrawParameters();			
			}
		}


		private void SelectParameterType(object data){
			mType = (Type)data;
		}

		private void Update(){
			if (paramterCollection == null && !EditorApplication.isCompiling && !EditorApplication.isCompiling) {
				paramterCollection = (GlobalParameterCollection)Resources.Load ("GlobalParameterCollection");
				if (paramterCollection == null) {
					if (!System.IO.Directory.Exists(Application.dataPath + "/State Machine/Resources")) {
						AssetDatabase.CreateFolder("Assets/State Machine", "Resources");
					}	
					paramterCollection= AssetCreator.CreateAsset<GlobalParameterCollection>("Assets/State Machine/Resources/GlobalParameterCollection.asset");
					EditorUtility.DisplayDialog("Created GlobalParameterCollection!",
					                            "Do not delete or rename the Resource folder and the GlobalParameterCollection asset.", "Ok");
					if(paramterCollection.parameters == null){
						paramterCollection.parameters= new List<NamedParameter>();
					}
				}
				paramterCollection.parameters.Sort((a, b) =>  a.Group.CompareTo(b.Group));
			}
			Repaint ();
		}

		private Dictionary<string,List<NamedParameter>> GetGroupParameters(){
			Dictionary<string,List<NamedParameter>> groupParameters = new Dictionary<string, List<NamedParameter>> ();
			foreach (NamedParameter parameter in paramterCollection.parameters) {
				if(string.IsNullOrEmpty(parameter.Group)){
					parameter.Group="Default";
				}
				if(!groupParameters.ContainsKey(parameter.Group)){
					groupParameters.Add(parameter.Group,new List<NamedParameter>(){parameter});
				}else{
					groupParameters[parameter.Group].Add(parameter);
				}			
			}
			return groupParameters;
		}

		private void DrawParameters(){

			NamedParameter delete = null;
			scroll = GUILayout.BeginScrollView (scroll);
			Dictionary<string,List<NamedParameter>> groupParameters = GetGroupParameters ();
			EditorGUIUtility.labelWidth = 140;
			foreach (var kvp in groupParameters) {

				bool foldout=EditorPrefs.GetBool(kvp.Key,false);
				bool state=EditorGUILayout.Foldout(foldout,kvp.Key);
				if(state!= foldout){
					EditorPrefs.SetBool(kvp.Key,state);
				}
				if(foldout){
					for (int i=0; i< groupParameters[kvp.Key].Count;i++) {
						NamedParameter parameter=groupParameters[kvp.Key][i];
						if(parameter != null){
							SerializedObject paramObject= new SerializedObject(parameter);
							SerializedProperty prop=paramObject.FindProperty("value");	
							GUILayout.BeginHorizontal();
							GUILayout.Space(16f);
							string name=paramObject.FindProperty("parameterName").stringValue;
							if(parameter is ObjectParameter){
								GUI.changed=false;
								ObjectParameter mParam=parameter as ObjectParameter;
								if(!mParam.FromSceneInstance){
									mParam.Value=EditorGUILayout.ObjectField(name,mParam.Value,typeof(UnityEngine.Object),true);
								}else{
									GUILayout.Label(name, GUILayout.Width(136));
									GUIStyle style = new GUIStyle ("label");
									style.fixedHeight = 0;
									style.wordWrap = true;
									style.alignment=TextAnchor.UpperLeft;
									GUILayout.Label (mParam.Reference, style);
									GUILayout.FlexibleSpace();
								}

								if(GUI.changed){
									if(!EditorUtility.IsPersistent(mParam.Value) && mParam.Value is GameObject){
										mParam.FromSceneInstance=true;
										mParam.Reference=mParam.Value.name+"("+EditorApplication.currentScene+")";
										AddToParameterCollection mTemp=((GameObject)mParam.Value).GetComponent<AddToParameterCollection>();
										if(mTemp == null){
											mTemp=((GameObject)mParam.Value).AddComponent<AddToParameterCollection>();
										}
										mTemp.paramterName=mParam.Name;
									}
									EditorUtility.SetDirty(mParam);
								}
							}else{
								paramObject.Update();
								if(prop != null){
									EditorGUILayout.PropertyField(prop,new GUIContent(name),true);
								}
								paramObject.ApplyModifiedProperties();
							}

							if (GUILayout.Button ("down",EditorStyles.toolbarButton,GUILayout.Width(35))) {
								if(i<groupParameters[kvp.Key].Count){
									int indexToMove=paramterCollection.parameters.FindIndex(x=>x.Name==parameter.Name);
									paramterCollection.parameters.Move(indexToMove,0);
									EditorUtility.SetDirty(paramterCollection);
								}
							}
							if (GUILayout.Button ("up",EditorStyles.toolbarButton,GUILayout.Width(20))) {
								if(i>0){
									int indexToMove=paramterCollection.parameters.FindIndex(x=>x.Name==parameter.Name);
									paramterCollection.parameters.Move(indexToMove,1);
									EditorUtility.SetDirty(paramterCollection);
								}
							}

							if (GUILayout.Button (parameter.Group,EditorStyles.toolbarDropDown,GUILayout.Width(50))) {
								GenericMenu menu= new GenericMenu();
								foreach(NamedParameter p in paramterCollection.parameters){
									string group=p.Group;
									NamedParameter mParam=parameter;
									menu.AddItem(new GUIContent(group),mParam.Group==group,delegate() {
										mParam.Group=group;
									});
								}
								menu.ShowAsContext();
							}

							if(GUILayout.Button(EditorGUIUtility.FindTexture("Toolbar Minus"),"label",GUILayout.Width(20))){
								delete=parameter;
							}
							
							GUILayout.EndHorizontal();
						}
					}			        
				}
			}

			if (delete != null) {
				paramterCollection.parameters.Remove(delete);
				DestroyImmediate(delete,true);
				EditorUtility.SetDirty(paramterCollection);
			}

			GUILayout.EndScrollView ();

		}

		private void CreateParameter(){
			NamedParameter parameter = (NamedParameter)ScriptableObject.CreateInstance (mType);
			parameter.Name = parameterName;
			parameter.Group = parameterGroup;
			parameter.name = mType.ToString ();

			AssetDatabase.AddObjectToAsset (parameter, paramterCollection);
			AssetDatabase.SaveAssets();
			if (paramterCollection.parameters == null) {
				paramterCollection.parameters=new List<NamedParameter>();			
			}
			paramterCollection.parameters.Add (parameter);
			EditorUtility.SetDirty (paramterCollection);
		}

	}
}