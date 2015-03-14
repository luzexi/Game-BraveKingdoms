using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using StateMachine;

namespace StateMachine{
	public class StateMachineWindow : EditorWindow {
		public static StateMachineWindow instance;
		private const float inspectorMinWidth=150f;
		private const float inspectorMaxWidth=555f;

		[SerializeField]
		private StateMachineEditor stateMachineEditor;
		[SerializeField]
		private CustomInspector customInspector;
		[SerializeField]
		private bool showInspector;
		[SerializeField]
		private float inspectorWidth = 265f;
		[SerializeField]
		private Rect resizeRect;
		[SerializeField]
		private Rect canvasRect;
		[SerializeField]
		private Rect inspectorRect;
		[SerializeField]
		private Rect toolbarRect;

		public static StateMachineWindow ShowWindow()
		{
			StateMachineWindow window = EditorWindow.GetWindow<StateMachineWindow>("StateMachine");
			UnityEngine.Object.DontDestroyOnLoad(window);
			if(PreferencesEditor.GetBool(Preference.ShowWelcomeWindow)){
				WelcomeWindow.ShowWindow();
			}
			return window;
		}

		private void OnEnable(){
			if (stateMachineEditor == null) {
				stateMachineEditor=ScriptableObject.CreateInstance<StateMachineEditor>();	
			}
			if (customInspector == null) {
				customInspector=ScriptableObject.CreateInstance<CustomInspector>();	
			}

			if (instance == null) {
				instance = this;
			}
		}

		private void OnGUI(){
			DoEvents ();
			UpdateWindow ();
			stateMachineEditor.DoOnGUI (canvasRect);
			if(showInspector)
			customInspector.InspectorGUI (inspectorRect);
		}

		private void UpdateWindow(){
			showInspector = PreferencesEditor.GetBool (Preference.CustomInspector);
			canvasRect=new Rect(0,0,position.width-(showInspector?inspectorWidth:0),position.height);
			inspectorRect=new Rect(canvasRect.width,canvasRect.y,inspectorWidth,canvasRect.height);
			resizeRect=new Rect (canvasRect.width - 5, canvasRect.y, 10, canvasRect.height);
		}
	
		public static void RepaintAll(){
			if (instance != null) {
				instance.Repaint();			
			}
			ConditionBrowser.RepaintAll ();
			ActionBrowser.RepaintAll ();
		}

		public static StateMachineEditor StateMachineEditor{
			get {
				return instance != null?instance.stateMachineEditor:null;
			}
		}
	
		public static CustomInspector CustomInspector{
			get{
				return instance != null?instance.customInspector:null;
			}
		}

		private void OnSelectionChange(){
			stateMachineEditor.OnSelectionChange ();
		}
		
		public void SetStateMachine(StateMachine stateMachine){
			stateMachineEditor.ActiveStateMachine = stateMachine;
		}

		private void OnDestroy(){
			DestroyImmediate (StateMachineEditor, true);
			DestroyImmediate (CustomInspector, true);
			Selection.activeObject = null;
			instance = null;
		}

		private void DoEvents(){
			if (showInspector) {
				EditorGUIUtility.AddCursorRect (resizeRect, MouseCursor.ResizeHorizontal);	
				int controlID = GUIUtility.GetControlID(GUIControl.GetID (Control.InspectorWidthChange),FocusType.Passive);
				Event ev = Event.current;
				switch (ev.type) {
				case EventType.MouseDown:
					if (ev.button == 0 && resizeRect.Contains (ev.mousePosition)) {
						GUIUtility.hotControl = controlID;
						ev.Use ();	
					}
					break;
				case EventType.MouseUp:
					if(GUIUtility.hotControl==controlID){
						GUIUtility.hotControl = 0;
						ev.Use();
					}
					break;
				case EventType.MouseDrag:
					if (GUIUtility.hotControl == controlID) {
						inspectorWidth = position.width - ev.mousePosition.x;
						inspectorWidth = Mathf.Clamp (inspectorWidth, inspectorMinWidth, inspectorMaxWidth);
						ev.Use ();
					}
					break;
				}
			} 	
		}

		[DrawGizmo(GizmoType.SelectedOrChild | GizmoType.NotSelected)]
		static void DrawGameObjectName(Transform transform, GizmoType gizmoType)
		{   
			StateMachineBehaviour behaviour = transform.GetComponent<StateMachineBehaviour> ();
			
			if (behaviour != null && behaviour.currentState != null && behaviour.debug) { 
				var centeredStyle = new GUIStyle( GUI.skin.GetStyle("HelpBox"));
				centeredStyle.alignment = TextAnchor.UpperCenter;
				centeredStyle.fontSize=21;
				Handles.Label (transform.position, behaviour.currentState.name,centeredStyle);
			}
		}

	}
}