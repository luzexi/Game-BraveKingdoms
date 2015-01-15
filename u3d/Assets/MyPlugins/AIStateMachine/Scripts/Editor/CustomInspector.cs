using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine{
	[System.Serializable]
	public class CustomInspector:ScriptableObject  {
		[SerializeField]
		private Editor editor;
		[SerializeField]
		private  List<State> selectedStates;
		public List<State> SelectedStates {
			get{
				return selectedStates;
			}
			set{
				selectedStates = value;
				DestroyImmediate(editor);
				editor=Editor.CreateEditor(selectedStates.ToArray(),typeof(StateInspector));
			}
		}
		[SerializeField]
		private Vector2 scroll;

		private void OnEnable(){
			hideFlags = HideFlags.HideAndDontSave;
			if(selectedStates== null){
				selectedStates= new List<State>();
			}
		}

		private int selectedTool;
		private string[] tools= new string[]{"FSM","State","Layer"};

		public void InspectorGUI(Rect position){
			GUILayout.BeginArea (position);
			GUILayout.Space (12);
			scroll=GUILayout.BeginScrollView(scroll);
			switch(selectedTool){
			case 0:
				StateMachine stateMachine=StateMachineWindow.StateMachineEditor.ActiveStateMachine;
				if(stateMachine != null){
					
					GUILayout.BeginVertical ("IN BigTitle");
					GUILayout.BeginHorizontal();
					EditorGUIUtility.labelWidth = 50;
					string oldName = AssetDatabase.GetAssetPath (stateMachine);
					string newName =stateMachine.name;
					newName  = EditorGUILayout.TextField ("Name", newName);
					if(oldName != newName)
						AssetDatabase.RenameAsset (oldName, newName);
					GUILayout.EndHorizontal ();
					GUILayout.Label("Description:");
					stateMachine.description = EditorGUILayout.TextArea (stateMachine.description, GUILayout.MinHeight (45));
					GUILayout.EndVertical ();
					if(GUI.changed){
						EditorUtility.SetDirty(stateMachine);
					}
				}
				break;
			case 1:
				GUILayout.Space(5);
				if (SelectedStates.Count == 1 && editor != null) {
					editor.DrawHeader();
					GUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins);
					editor.OnInspectorGUI();
					GUILayout.EndVertical();
				} else if(SelectedStates.Count>1){
					GUILayout.Space(10f);
					GUILayout.BeginHorizontal();
					GUILayout.Space(10f);
					GUILayout.Label("Multi-state editing not supported.",FsmStyles.WrappedLabel);		
					GUILayout.EndHorizontal();
				}else{
					GUILayout.Label("Select a state.");
				}
				break;
			case 2:
				GUILayout.Space(10);
				GUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins);
				GUILayout.Label("Coming Soon");
				//DropAreaGUI();
				GUILayout.Space(10);
				GUILayout.EndVertical();
				break;
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea ();
			DoToolbar (position);
		}

		public void DropAreaGUI ()
		{
			Event evt = Event.current;
			GUIStyle style = new GUIStyle ("SelectionRect");
			style.fixedHeight = 0;
			style.wordWrap = true;
			GUIContent content = new GUIContent ("Drag and drop an existing StateMachine to add it as layer or click to create a new layer.");
			Rect drop_area = GUILayoutUtility.GetRect (content,style);
			GUI.Box (drop_area, content,style);
			
			switch (evt.type) {
			case EventType.MouseDown:
				if(drop_area.Contains(evt.mousePosition)){
					StateMachine stateMachine=StateMachineWindow.StateMachineEditor.ActiveStateMachine.root;
					StateMachine layerStateMachine=ScriptableObject.CreateInstance<StateMachine>();
					layerStateMachine.root=stateMachine;
					layerStateMachine.layer=(stateMachine.layers.Count+1);
					layerStateMachine.name="Layer "+layerStateMachine.layer.ToString();
					if(EditorUtility.IsPersistent(stateMachine)){
						AssetDatabase.AddObjectToAsset(layerStateMachine,stateMachine);
						AssetDatabase.SaveAssets();
					}
					StateMachineUtility.CreateAnyState(new Vector2(GraphEditor.MaxCanvasSize,GraphEditor.MaxCanvasSize)*0.5f,layerStateMachine);
					stateMachine.layers.Add(layerStateMachine);
					
					EditorUtility.SetDirty(stateMachine);
					Event.current.Use();
				}
				break;
			case EventType.DragUpdated:
			case EventType.DragPerform:
				if (!drop_area.Contains (evt.mousePosition))
					return;
				
				DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
				
				if (evt.type == EventType.DragPerform) {
					DragAndDrop.AcceptDrag ();
					
					foreach (Object dragged_object in DragAndDrop.objectReferences) {
						if(dragged_object is StateMachine){
							Debug.Log(dragged_object);
						}
					}
				}
				break;
			}
		}

		private void DoToolbar(Rect position){
			GUILayout.BeginArea(position);
			 int tool = GUILayout.SelectionGrid (selectedTool, tools, tools.Length,EditorStyles.toolbarButton);
			if (tool != selectedTool) {
				selectedTool=tool;
				GUI.FocusControl("");
			}
			GUILayout.EndArea ();
		}
	}
}