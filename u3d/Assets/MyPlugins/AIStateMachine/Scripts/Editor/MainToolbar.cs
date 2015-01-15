using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine{
	[System.Serializable]
	public class MainToolbar{
		[SerializeField]
		private bool lockSelection;
		[SerializeField]
		private bool showPreferences;
		[SerializeField]
		private Texture settingsIcon;
		
		public MainToolbar(){
			lockSelection = PreferencesEditor.GetBool (Preference.LockSelection);
			showPreferences= PreferencesEditor.GetBool(Preference.ShowPreference);
			settingsIcon = EditorGUIUtility.FindTexture ("d__Popup");
		}
		
		public void OnGUI(){
			GUILayout.BeginHorizontal (FsmStyles.Toolbar);
			SelectGameObject ();
			SelectStateMachine ();
			
			if (GUILayout.Button ("Lock",(lockSelection?(GUIStyle)"TE toolbarbutton" : EditorStyles.toolbarButton), GUILayout.Width (50))) {
				lockSelection=!lockSelection;
				PreferencesEditor.SetBool(Preference.LockSelection,lockSelection);
			}

			if (GUILayout.Button ("Tools",EditorStyles.toolbarDropDown, GUILayout.Width (50))) {
				GenericMenu menu= new GenericMenu();
				menu.AddItem(new GUIContent("Global Parameter Editor"),false,delegate() {
					GlobalParameterEditor.ShowWindow();
				});
				menu.AddItem(new GUIContent("Action Browser"),false,delegate() {
					ActionBrowser.ShowWindow();
				});
				menu.AddItem(new GUIContent("Condition Browser"),false,delegate() {
					ConditionBrowser.ShowWindow();
				});
				menu.ShowAsContext();
			}

			GUILayout.FlexibleSpace ();
			if (GUILayout.Button(settingsIcon, (showPreferences?(GUIStyle)"TE toolbarbutton" : EditorStyles.toolbarButton))) {
				showPreferences=!showPreferences;
				PreferencesEditor.SetBool(Preference.ShowPreference,showPreferences);
			}


			GUILayout.EndHorizontal ();
		}
		
		private void SelectGameObject(){
			//GUILayout.Label(new GUIContent ("Test", EditorGUIUtility.FindTexture ("UnityEditor.InspectorWindow")));
			if (GUILayout.Button(StateMachineWindow.StateMachineEditor.ActiveGameObject != null?StateMachineWindow.StateMachineEditor.ActiveGameObject.name:"[None Selected]", EditorStyles.toolbarDropDown,GUILayout.Width(100))) {
				GenericMenu toolsMenu = new GenericMenu();
				List<StateMachineBehaviour> behaviours=FindInScene<StateMachineBehaviour>();
				foreach(StateMachineBehaviour behaviour in behaviours){
					if(behaviour.stateMachine != null){
						StateMachine mStateMachine= ((EditorApplication.isPlaying && !EditorApplication.isPaused) ? behaviour.executingStateMachine : behaviour.stateMachine);//behaviour.stateMachine;
						GameObject mGameObject=behaviour.gameObject;
						toolsMenu.AddItem( new GUIContent(behaviour.name),false, delegate() {
							StateMachineWindow.StateMachineEditor.ActiveGameObject=mGameObject;
							StateMachineWindow.StateMachineEditor.ActiveStateMachine=mStateMachine;
						});
					}
				}
				toolsMenu.DropDown(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,0,Event.current.mousePosition.y));
				EditorGUIUtility.ExitGUI();
			}
		}
		
		private void SelectStateMachine(){
			if (GUILayout.Button(StateMachineWindow.StateMachineEditor.ActiveStateMachine!= null?StateMachineWindow.StateMachineEditor.ActiveStateMachine.name:"[None Selected]", EditorStyles.toolbarDropDown,GUILayout.Width(100))) {
				GenericMenu toolsMenu = new GenericMenu();
				if(StateMachineWindow.StateMachineEditor.ActiveGameObject != null){
					foreach(StateMachineBehaviour behaviour in StateMachineWindow.StateMachineEditor.ActiveGameObject.GetComponents<StateMachineBehaviour>()){
						if(behaviour.stateMachine != null){
							StateMachine mStateMachine= ((EditorApplication.isPlaying && !EditorApplication.isPaused) ? behaviour.executingStateMachine : behaviour.stateMachine);// behaviour.stateMachine;
							toolsMenu.AddItem( new GUIContent(mStateMachine.name),false, delegate() {
								StateMachineWindow.StateMachineEditor.ActiveStateMachine=mStateMachine;
							});
						}
					}
					
				}
				toolsMenu.AddItem( new GUIContent("[Create New]"),false, delegate() {
					StateMachine stateMachine = StateMachineUtility.CreateStateMachine (true);
					StateMachineWindow.instance.SetStateMachine(stateMachine);
				});
				toolsMenu.DropDown(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,0,Event.current.mousePosition.y));
				EditorGUIUtility.ExitGUI();
			}
		}
		
		public static List<T> FindInScene<T> () where T : Component
		{
			T[] comps = Resources.FindObjectsOfTypeAll(typeof(T)) as T[];
			
			List<T> list = new List<T>();
			
			foreach (T comp in comps)
			{
				if (comp.gameObject.hideFlags == 0)
				{
					string path = AssetDatabase.GetAssetPath(comp.gameObject);
					if (string.IsNullOrEmpty(path)) list.Add(comp);
				}
			}
			return list;
		}
		
		
	}
}