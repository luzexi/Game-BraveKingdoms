using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using StateMachine.Condition;
using System.Reflection;

namespace StateMachine{
	public class ConditionBrowser :  EditorWindow{
		public static ConditionBrowser instance;
		public static void ShowWindow()
		{
			ConditionBrowser window = EditorWindow.GetWindow<ConditionBrowser>("Conditions");
			Vector2 size = new Vector2(250f, 250f);
			window.minSize = size;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}
		private Vector2 scroll;
		[SerializeField]
		private StateCondition selectedCondition;
		private double clickTime;
		private double doubleClickTime = 0.3;
		private Dictionary<string,List<Type>> conditions;
		private string searchString;
		
		private void OnGUI(){
			bool changed;
			GUILayout.BeginHorizontal ();
			searchString=UnityEditorTools.SearchField (searchString, out changed);
			GUIStyle labelStyle1= new GUIStyle("label");
			labelStyle1.contentOffset= new Vector2(0,2);
			if(GUILayout.Button(EditorGUIUtility.FindTexture("_popup"),labelStyle1,GUILayout.Width(20))){
				GenericMenu menu= new GenericMenu();
				
				menu.AddItem(new GUIContent("Close after adding condition"),PreferencesEditor.GetBool(Preference.CloseConditionBrowserOnAdd,false),delegate() {
					PreferencesEditor.SetBool(Preference.CloseConditionBrowserOnAdd,!PreferencesEditor.GetBool(Preference.CloseConditionBrowserOnAdd));
				});
				menu.AddItem(new GUIContent("Show Preview"),PreferencesEditor.GetBool(Preference.ConditionBrowserShowPreview,true),delegate() {
					PreferencesEditor.SetBool(Preference.ConditionBrowserShowPreview,!PreferencesEditor.GetBool(Preference.ConditionBrowserShowPreview));
				});
				menu.ShowAsContext();
			}
			GUILayout.EndHorizontal ();
			GUILayout.Space (2.0f);
			scroll = GUILayout.BeginScrollView (scroll);
			foreach (KeyValuePair<string,List<Type>> kvp in conditions) {
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
					foreach(Type conditionType in kvp.Value){
						if(!string.IsNullOrEmpty(searchString) && !conditionType.ToString().Split('.').Last().ToLower().StartsWith(searchString.ToLower())){
							continue;
						}
						Color color = GUI.contentColor;
						GUI.contentColor = (selectedCondition != null && conditionType==selectedCondition.GetType() ? EditorStyles.foldout.focused.textColor : color);
						
						if(GUILayout.Button(string.IsNullOrEmpty(searchString)?conditionType.ToString().Split('.').Last():conditionType.GetCategory()+"."+conditionType.ToString().Split('.').Last(),"label",GUILayout.ExpandWidth(true))){
							DestroySelectedCondition();
							
							StateCondition condition = (StateCondition)ScriptableObject.CreateInstance(conditionType);
							condition.hideFlags=HideFlags.HideAndDontSave;
							condition.name = conditionType.ToString ().Split ('.').Last ();
							FieldInfo[] fields = conditionType.GetFields ();
							
							for (int i=0; i< fields.Length; i++) {
								if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
									NamedParameter paramter=(NamedParameter)ScriptableObject.CreateInstance(fields[i].FieldType);
									paramter.hideFlags=HideFlags.HideAndDontSave;
									paramter.name=fields[i].Name;
									fields[i].SetValue(condition,paramter);
									if(fields[i].GetDefaultValue() != null){
										paramter.GetType().GetProperty("Value").SetValue(paramter,fields[i].GetDefaultValue(),null);
									}
								}		
							}		
							
							selectedCondition=condition;
							
							if ((EditorApplication.timeSinceStartup - clickTime) < doubleClickTime){
								if(StateMachineWindow.StateMachineEditor.ActiveStateMachine != null){
									int selectedStatesCount=StateMachineWindow.StateMachineEditor.selectedStates.Count;
									if(selectedStatesCount==0){
										Debug.Log("Please select a transition.");
									}else if(selectedStatesCount>0&& StateMachineWindow.StateMachineEditor.selectedStates[0].transitions.Count>0){

										StateMachineUtility.CreateCondition(StateMachineWindow.StateMachineEditor.selectedStates[0].transitions[StateMachineWindow.StateMachineEditor.transitionIndex],conditionType);

										if(PreferencesEditor.GetBool(Preference.CloseConditionBrowserOnAdd,false)){
											Close();
										}
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
			if (selectedCondition != null) {
				GUIStyle style = new GUIStyle("IN BigTitle");
				style.padding.top=0;
				GUILayout.BeginVertical(style);
				GUILayout.BeginHorizontal();
				GUILayout.Label(selectedCondition.name,EditorStyles.boldLabel);
				GUILayout.FlexibleSpace();
				GUIStyle labelStyle= new GUIStyle("label");
				labelStyle.contentOffset= new Vector2(0,5);
				if(!string.IsNullOrEmpty(selectedCondition.GetInfoUrl()) && GUILayout.Button(EditorGUIUtility.FindTexture ("_help"),labelStyle,GUILayout.Width(20))){
					Application.OpenURL(selectedCondition.GetInfoUrl());
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(3f);
				GUILayout.Label(selectedCondition.GetDescription(),FsmStyles.WrappedLabel);
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				
				if(StateMachineWindow.StateMachineEditor.ActiveStateMachine != null){
					int selectedStatesCount=StateMachineWindow.StateMachineEditor.selectedStates.Count;
					if(GUILayout.Button(selectedStatesCount>0&& StateMachineWindow.StateMachineEditor.selectedStates[0].transitions.Count>0?"Add to transition":"Select a transition to add")&& selectedStatesCount>0 && StateMachineWindow.StateMachineEditor.selectedStates[0].transitions.Count>0 ){
						StateMachineUtility.CreateCondition(StateMachineWindow.StateMachineEditor.selectedStates[0].transitions[StateMachineWindow.StateMachineEditor.transitionIndex],selectedCondition.GetType());

						if(PreferencesEditor.GetBool(Preference.CloseConditionBrowserOnAdd,false)){
							Close();
						}
					}
				}
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();
				
				if(PreferencesEditor.GetBool(Preference.ConditionBrowserShowPreview,true)){
					EditorGUI.BeginDisabledGroup(true);
					StateMachineGUI.DrawElement (selectedCondition,false,false);
					EditorGUI.EndDisabledGroup();
					GUILayout.Space(5);
				}
			}
		}
		
		private void DestroySelectedCondition(){
			if(selectedCondition != null){
				FieldInfo[] fields = selectedCondition.GetType().GetFields ();
				for (int i=0; i< fields.Length; i++) {
					if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
						UnityEngine.Object.DestroyImmediate((UnityEngine.Object)fields[i].GetValue(selectedCondition),true);
					}		
				}
				DestroyImmediate(selectedCondition,true);
			}
		}

		public static void RepaintAll() {
			if (instance != null) {
				instance.Repaint();			
			}
		}

		private void OnEnable(){
			if (instance == null) {
				instance = this;
			}
			conditions = GetConditionTypesSorted ();
		}
		
		private void Update(){
			if (StateMachineWindow.instance == null) {
				Close();			
			}		
		}
		
		private void OnDestroy(){
			instance = null;
			DestroySelectedCondition ();
		}
		
		private Dictionary<string,List<Type>> GetConditionTypesSorted(){
			List<Type> types = GetConditionTypes ();
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
		
		private List<Type> GetConditionTypes(){
			List<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(StateCondition))).ToList();
			types.Sort(delegate(Type p1, Type p2) {return p1.GetCategory().CompareTo(p2.GetCategory());});
			return types;
		}
	}
}