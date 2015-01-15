using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using StateMachine.Action;
using System.Reflection;

namespace StateMachine{
	public class ActionBrowser :  EditorWindow{
		public static ActionBrowser instance;
		public static void ShowWindow()
		{
			ActionBrowser window = EditorWindow.GetWindow<ActionBrowser>("Actions");
			Vector2 size = new Vector2(250f, 250f);
			window.minSize = size;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}
		private Vector2 scroll;
		[SerializeField]
		private StateAction selectedAction;
		private double clickTime;
		private double doubleClickTime = 0.3;
		private Dictionary<string,List<Type>> actions;
		private string searchString;

		private void OnGUI(){
			bool changed;
			GUILayout.BeginHorizontal ();
			searchString=UnityEditorTools.SearchField (searchString, out changed);
			GUIStyle labelStyle1= new GUIStyle("label");
			labelStyle1.contentOffset= new Vector2(0,2);
			if(GUILayout.Button(EditorGUIUtility.FindTexture("_popup"),labelStyle1,GUILayout.Width(20))){
				GenericMenu menu= new GenericMenu();
			
				menu.AddItem(new GUIContent("Close after adding action"),PreferencesEditor.GetBool(Preference.CloseActionBrowserOnAdd,false),delegate() {
					PreferencesEditor.SetBool(Preference.CloseActionBrowserOnAdd,!PreferencesEditor.GetBool(Preference.CloseActionBrowserOnAdd));
				});
				menu.AddItem(new GUIContent("Show Preview"),PreferencesEditor.GetBool(Preference.ActionBrowserShowPreview,true),delegate() {
					PreferencesEditor.SetBool(Preference.ActionBrowserShowPreview,!PreferencesEditor.GetBool(Preference.ActionBrowserShowPreview));
				});
				menu.ShowAsContext();
			}
			GUILayout.EndHorizontal ();
			GUILayout.Space (2.0f);
			scroll = GUILayout.BeginScrollView (scroll);
			foreach (KeyValuePair<string,List<Type>> kvp in actions) {
				bool foldout=EditorPrefs.GetBool(kvp.Key,false);
				if(string.IsNullOrEmpty(searchString)){
					if (GUILayout.Button (kvp.Key,(foldout?(GUIStyle)"TE toolbarbutton" : EditorStyles.toolbarButton))) {
						foldout=!foldout;
						EditorPrefs.SetBool(kvp.Key,foldout);
					}
				}else{
					foldout=true;
				}
				if(foldout){
					foreach(Type actionType in kvp.Value){
						if(!string.IsNullOrEmpty(searchString) && !actionType.ToString().Split('.').Last().ToLower().StartsWith(searchString.ToLower())){
							continue;
						}
						Color color = GUI.contentColor;
						GUI.contentColor = (selectedAction != null && actionType==selectedAction.GetType() ? EditorStyles.foldout.focused.textColor : color);

						if(GUILayout.Button(string.IsNullOrEmpty(searchString)?actionType.ToString().Split('.').Last():actionType.GetCategory()+"."+actionType.ToString().Split('.').Last(),"label",GUILayout.ExpandWidth(true))){
							DestroySelectedAction();

							StateAction action = (StateAction)ScriptableObject.CreateInstance(actionType);
							action.hideFlags=HideFlags.HideAndDontSave;
							action.name = actionType.ToString ().Split ('.').Last ();
							FieldInfo[] fields = actionType.GetFields ();
							
							for (int i=0; i< fields.Length; i++) {
								if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
									NamedParameter paramter=(NamedParameter)ScriptableObject.CreateInstance(fields[i].FieldType);
									paramter.hideFlags=HideFlags.HideAndDontSave;
									paramter.name=fields[i].Name;
									fields[i].SetValue(action,paramter);
									if(fields[i].GetDefaultValue() != null){
										paramter.GetType().GetProperty("Value").SetValue(paramter,fields[i].GetDefaultValue(),null);
									}
								}		
							}		

							selectedAction=action;

							if ((EditorApplication.timeSinceStartup - clickTime) < doubleClickTime){
								if(StateMachineWindow.StateMachineEditor.ActiveStateMachine != null){
									int selectedStatesCount=StateMachineWindow.StateMachineEditor.selectedStates.Count;
									if(selectedStatesCount==0){
										Debug.Log("Please select a state.");
									}else if(selectedStatesCount==1){
										StateMachineUtility.CreateAction(StateMachineWindow.StateMachineEditor.selectedStates[0],actionType);
										if(PreferencesEditor.GetBool(Preference.CloseActionBrowserOnAdd,false)){
											Close();
										}
									}else{
										Debug.Log("Please select only one state!");
									}
								}
							}
							
							clickTime = EditorApplication.timeSinceStartup;
						}   
						GUI.contentColor=color;
					}
				}
			}	
			GUILayout.EndScrollView ();
			if (selectedAction != null) {
				GUIStyle style = new GUIStyle("IN BigTitle");
				style.padding.top=0;
				GUILayout.BeginVertical(style);
				GUILayout.BeginHorizontal();
				GUILayout.Label(selectedAction.name,EditorStyles.boldLabel);
				GUILayout.FlexibleSpace();
				GUIStyle labelStyle= new GUIStyle("label");
				labelStyle.contentOffset= new Vector2(0,5);
				if(!string.IsNullOrEmpty(selectedAction.GetInfoUrl()) && GUILayout.Button(EditorGUIUtility.FindTexture ("_help"),labelStyle,GUILayout.Width(20))){
					Application.OpenURL(selectedAction.GetInfoUrl());
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(3f);
				GUILayout.Label(selectedAction.GetDescription(),FsmStyles.WrappedLabel);
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();

				if(StateMachineWindow.StateMachineEditor.ActiveStateMachine != null){
					int selectedStatesCount=StateMachineWindow.StateMachineEditor.selectedStates.Count;
					if(GUILayout.Button(selectedStatesCount>0?"Add to state":"Select a state to add")&& selectedStatesCount>0){
						StateMachineUtility.CreateAction(StateMachineWindow.StateMachineEditor.selectedStates[0],selectedAction.GetType());
						if(PreferencesEditor.GetBool(Preference.CloseActionBrowserOnAdd,false)){
							Close();
						}
					}
				}
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();

				if(PreferencesEditor.GetBool(Preference.ActionBrowserShowPreview,true)){
					EditorGUI.BeginDisabledGroup(true);
					StateMachineGUI.DrawElement (selectedAction,false,false);
					EditorGUI.EndDisabledGroup();
					GUILayout.Space(5);
				}
			}
		}

		private void DestroySelectedAction(){
			if(selectedAction != null){
				FieldInfo[] fields = selectedAction.GetType().GetFields ();
				for (int i=0; i< fields.Length; i++) {
					if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
						UnityEngine.Object.DestroyImmediate((UnityEngine.Object)fields[i].GetValue(selectedAction),true);
					}		
				}
				DestroyImmediate(selectedAction,true);
			}
		}

		private void OnEnable(){
			if (instance == null) {
				instance=this;			
			}
			actions = GetActionTypesSorted ();
		}

		private void Update(){
			if (StateMachineWindow.instance == null) {
				Close();			
			}		
		}

		private void OnDestroy(){
			instance = null;
			DestroySelectedAction ();
		}

		public static void RepaintAll() {
			if (instance != null) {
				instance.Repaint();			
			}
		}

		private Dictionary<string,List<Type>> GetActionTypesSorted(){
			List<Type> types = GetActionTypes ();
			Dictionary<string,List<Type>> sorted = new Dictionary<string, List<Type>> ();
			foreach (Type type in types) {
				string category=type.GetCategory();
				if(!string.IsNullOrEmpty(category)){
					if(sorted.ContainsKey(category)){
						sorted[category].Add(type);
					}else{
						sorted.Add(category,new List<Type>(){type});
					}
				}
			}
			return sorted;
		}

		private List<Type> GetActionTypes(){
			List<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(StateAction))).ToList();
			types.Sort(delegate(Type p1, Type p2) {return p1.GetCategory().CompareTo(p2.GetCategory());});
			return types;
		}
	}
}