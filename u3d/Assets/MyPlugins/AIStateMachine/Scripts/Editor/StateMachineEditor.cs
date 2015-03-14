using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using StateMachine.Action;
using StateMachine.Condition;

namespace StateMachine{
	[System.Serializable]
	public class StateMachineEditor : GraphEditor {
		[SerializeField]
		private PreferencesEditor preferencesEditor;
		[SerializeField]
		private MainToolbar mainToolbar;
		public List<State> selectedStates;
		private Vector2 selectionStartPoint;
		public EventMode eventMode;
		private int connectionIndex=-1;
		public int transitionIndex=0;
		private bool centerView;

		[SerializeField]
		private StateMachine activeStateMachine;
		public StateMachine ActiveStateMachine{
			get{
				return activeStateMachine;
			}
			set{
				activeStateMachine=value;
				List<State> newSelection= new List<State>();
				foreach(State state in selectedStates){
					newSelection.AddRange(activeStateMachine.states.FindAll(x=>x.id==state.id));
				}
				selectedStates=newSelection;
				UpdateSelection();
				centerView = true;
			}
		}

		[SerializeField]
		private GameObject activeGameObject;
		public GameObject ActiveGameObject{
			get{
				return activeGameObject;
			}
			set{
				activeGameObject=value;
			}
		}


		private void OnEnable(){
			hideFlags = HideFlags.HideAndDontSave;

			if(preferencesEditor == null){
				preferencesEditor= new PreferencesEditor();
			}

			if (mainToolbar == null) {
				mainToolbar = new MainToolbar();			
			}

			if (selectedStates == null) {
				selectedStates= new List<State>();			
			}
			EditorApplication.playmodeStateChanged += OnPlayModeStateChanged;
			EditorApplication.update = Update;
		}

	
		public void DoOnGUI(Rect position){
			GUILayout.BeginArea (position);
			mainToolbar.OnGUI ();
			GUILayout.EndArea ();
			Rect preferencesRect =PreferencesEditor.GetBool(Preference.ShowPreference)?new Rect (position.width - 202, 18, 200, 142):new Rect();
			this.graphRect =  new Rect (position.x, position.y + 18, position.width, position.height - 18);
			Rect parametersRect = new Rect (0, position.height - GetParametersHeight(), 250, GetParametersHeight());
			HandleKeyEvents ();
			EventType eventType = StateMachineUtility.ReserveEvent (preferencesRect,parametersRect);
			BeginGraphGUI ();
			DoStates ();
			StateMachineGUI.CanvasContextMenu (this);
			EndGraphGUI ();
			StateMachineUtility.ReleaseEvent (eventType);
			DoParameters(parametersRect);
			DoHelp (new Rect (position.width - 260, 0, 260, position.height));
			DoInfo (PreferencesEditor.GetBool(Preference.ShowShortcuts)?new Rect (position.width - 260-265, 0, 260, position.height):new Rect (position.width - 260, 0, 260, position.height));
			preferencesEditor.OnGUI (preferencesRect);
			if (MouseInstruction.DoMouseInstruction ()) {
				StateMachineWindow.RepaintAll();		
			}
			if (centerView) {
				CenterView();
				centerView=false;
			}
			if(ActiveStateMachine != null)
			GUI.Label (new Rect (5, 20, 300, 200), ActiveStateMachine.description,FsmStyles.DescriptionLabel);
		}


		#region Help
		private bool showHelp;
		private void DoHelp(Rect position){
			showHelp = PreferencesEditor.GetBool (Preference.ShowShortcuts);
			
			if (showHelp) {
				GUILayout.BeginArea (position);
				GUILayout.FlexibleSpace();
				GUILayout.BeginVertical((GUIStyle)"U2D.createRect");
				HelpGUI ("Show Help", "F1");
				HelpGUI ("Show Info", "F2");
				HelpGUI ("Select All", "F3");
				HelpGUI ("Create State", "Ctrl+Click Canvas");
				HelpGUI ("Make Transition", "Alt");
				HelpGUI ("Select Center", "Tab");
				HelpGUI ("Action Browser", "Ctrl+A");
				HelpGUI ("Condition Browser", "Ctrl+C");
				GUILayout.EndVertical();
				GUILayout.EndArea ();
			}
		}

		
		private void HelpGUI(string title,string shortcut){
			GUILayout.BeginHorizontal ();
			GUILayout.Label(title,FsmStyles.ShortcutLabel,GUILayout.Width(130));
			GUILayout.Label(shortcut,FsmStyles.ShortcutLabel);
			GUILayout.EndHorizontal ();
		}
		
		private void HandleKeyEvents(){
			Event ev = Event.current;
			switch (ev.type) {
			case EventType.KeyDown:
				if (ev.keyCode == KeyCode.F1) {
					showHelp=!showHelp;
					PreferencesEditor.SetBool(Preference.ShowShortcuts,showHelp);
					ev.Use();
				}
				if(ev.keyCode== KeyCode.Tab){
					CenterView();

				}

				if(ev.keyCode== KeyCode.F2){
					showInfo=!showInfo;
					PreferencesEditor.SetBool(Preference.ShowInfo,showInfo);
					ev.Use();
				}
				
				if(ev.keyCode== KeyCode.F3){
					if(selectedStates.Count == ActiveStateMachine.states.Count){
						selectedStates.Clear();
					}else{
						selectedStates.Clear();
						selectedStates.AddRange(ActiveStateMachine.states);
					}
					UpdateSelection();
					ev.Use();
				}
				
				if(ev.keyCode== KeyCode.LeftAlt){
					//GUIUtility.hotControl = GUIControl.GetID(Control.MakeTransition);
					eventMode=EventMode.MakeTransition;
					MouseInstruction.Set("Select a state you want to transition from.");
					ev.Use();
				}

				break;
			case EventType.KeyUp:
				
				if(ev.control && ev.keyCode== KeyCode.A){
					ActionBrowser.ShowWindow();
					ev.Use();
				}
				if(ev.control && ev.keyCode== KeyCode.C){
					ConditionBrowser.ShowWindow();
					ev.Use();
				}
				break;
			}
			
		}
		#endregion

		#region Info
		private bool showInfo;
		private void DoInfo(Rect position){
			showInfo = PreferencesEditor.GetBool (Preference.ShowInfo);
			if (showInfo) {
				GUILayout.BeginArea (position);
				GUILayout.FlexibleSpace();
				GUILayout.BeginVertical((GUIStyle)"U2D.createRect");
				InfoGUI ("States", ActiveStateMachine.states.Count.ToString());
				int actions=0;
				int transitions=0;
				int conditions=0;
				foreach(State state in ActiveStateMachine.states){
					if(state.actions != null){
						actions+=state.actions.Count;
						if(state.transitions != null){
							transitions+=state.transitions.Count;
							foreach(StateTransition transition in state.transitions){
								if(transition.conditions != null){
									conditions+=transition.conditions.Count;
								}
							}
						}
					}
				}
				InfoGUI ("Actions", actions.ToString());
				InfoGUI ("Transitions", transitions.ToString());
				InfoGUI ("Conditions", conditions.ToString());
				InfoGUI ("Parameters", ActiveStateMachine.parameters.Count.ToString());
				GUILayout.EndVertical();
				GUILayout.EndArea();
			}
		}

		private void InfoGUI(string title,string info){
			GUILayout.BeginHorizontal ();
			GUILayout.Label(title,FsmStyles.ShortcutLabel,GUILayout.Width(130));
			GUILayout.Label(info,FsmStyles.ShortcutLabel);
			GUILayout.EndHorizontal ();
		}
		#endregion

		#region Parameter
		private float GetParametersHeight(){
			int cnt = ActiveStateMachine!= null? ActiveStateMachine.parameters.Count:0;
			bool foldOut = EditorPrefs.GetBool ("Parameters", false);
			return 22 + (foldOut?22 * cnt + (cnt == 0 ? 1 : 0) * 22:0);
			
		}
		
		[SerializeField]
		private Vector2 parameterScroll;
		private void DoParameters(Rect position){
			if (ActiveStateMachine == null) {
				return;			
			}
			GUILayout.BeginArea(position);
			GUILayout.FlexibleSpace ();
			GUILayout.BeginVertical ();
			bool state = EditorPrefs.GetBool ("Parameters", false);
			
			Rect rect = GUILayoutUtility.GetRect (new GUIContent("Parameters"), "flow overlay header lower left", GUILayout.ExpandWidth (true));
			rect.x -= 1;
			rect.width += 3;
			Rect rect2 = new Rect (rect.x+230,rect.y+2,20,20);
			
			if (GUI.Button (rect2,"","label")) {
				GenericMenu genericMenu = new GenericMenu ();
				IEnumerable<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(NamedParameter)));
				foreach(Type type in types){
					Type mType=type;
					genericMenu.AddItem (new GUIContent (type.ToString().Split('.').Last().Replace("Parameter","")), false, delegate() {
						StateMachineUtility.CreateParameter(mType,ActiveStateMachine);
					});
					
				}
				genericMenu.ShowAsContext ();
				Event.current.Use();
			}
			
			if (GUI.Button (rect,"Parameters", "flow overlay header lower left")) {
				EditorPrefs.SetBool("Parameters",!state);	
				Event.current.Use();
			}
			
			GUI.Label (rect2, EditorGUIUtility.FindTexture ("Toolbar Plus"));
			if (state) {
				parameterScroll=GUILayout.BeginScrollView(parameterScroll);
				GUIStyle style=new GUIStyle("PopupCurveSwatchBackground");
				style.padding=new RectOffset();
				GUILayout.BeginVertical (style, GUILayout.ExpandWidth (true));
				int deleteIndex=-1;
				if(ActiveStateMachine.parameters != null && ActiveStateMachine.parameters.Count>0){
					for(int i=0;i< ActiveStateMachine.parameters.Count;i++){
						NamedParameter parameter= ActiveStateMachine.parameters[i];
						SerializedObject paramObject= new SerializedObject(parameter);
						SerializedProperty prop=paramObject.FindProperty("value");
						
						GUILayout.BeginHorizontal();
						paramObject.Update();
						
						if(prop != null && prop.isArray &&  parameter.GetType() != typeof(StringParameter)){
							prop.isExpanded=EditorGUILayout.Toggle(GUIContent.none,prop.isExpanded,"foldout",GUILayout.Width(17));
						}
						EditorGUILayout.PropertyField(paramObject.FindProperty("parameterName"),GUIContent.none,true);
						
						if(prop != null){
							if(parameter is BoolParameter){
								EditorGUILayout.PropertyField(prop,GUIContent.none,true,GUILayout.Width(20));
							}else{
								if(!prop.isArray || parameter.GetType() == typeof(StringParameter))
									EditorGUILayout.PropertyField(prop,GUIContent.none,false);
							}
						}
						
						
						GUILayout.FlexibleSpace();
						if(GUILayout.Button(EditorGUIUtility.FindTexture("Toolbar Minus"),"label")){
							deleteIndex=i;
						}
						
						GUILayout.EndHorizontal();
						if(prop != null && prop.isArray && prop.isExpanded && parameter.GetType() != typeof(StringParameter)){
							EditorGUILayout.PropertyField(prop.FindPropertyRelative("Array.size"));
							for(int element=0; element < prop.arraySize;element++){
								SerializedProperty mProp=prop.GetArrayElementAtIndex(element);
								if(mProp != null)
								EditorGUILayout.PropertyField(mProp,GUIContent.none,true);
							}
						}
						
						paramObject.ApplyModifiedProperties();
					}
					
				}else{
					GUILayout.Label("List is Empty");
				}
				if(deleteIndex != -1){
					StateMachineUtility.RecordUndo(ActiveStateMachine);
					DestroyImmediate(ActiveStateMachine.parameters[deleteIndex],true);
					ActiveStateMachine.parameters.RemoveAt(deleteIndex);
					AssetDatabase.SaveAssets();
				}
				GUILayout.EndVertical ();
				GUILayout.EndScrollView();
			}
			
			GUILayout.EndVertical ();
			GUILayout.EndArea();
		}
		

		
		#endregion


		public void OnSelectionChange(){
			if (!PreferencesEditor.GetBool(Preference.LockSelection) && Selection.activeGameObject != null) {
				StateMachineBehaviour behaviour = Selection.activeGameObject.GetComponent<StateMachineBehaviour> ();
				if(behaviour !=  null){
					StateMachine mStateMachine = ((EditorApplication.isPlaying && !EditorApplication.isPaused) ? behaviour.executingStateMachine : behaviour.stateMachine);
					if (mStateMachine != null) {
						ActiveStateMachine=mStateMachine;
						ActiveGameObject=behaviour.gameObject;
						StateMachineWindow.RepaintAll();
					}
				}	
			}
		}

		public void OnPlayModeStateChanged(){
			if (ActiveStateMachine != null && ActiveStateMachine.behaviour != null) {
				StateMachine mStateMachine = ((EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying && !EditorApplication.isPaused) ? ActiveStateMachine.behaviour.executingStateMachine : ActiveStateMachine.behaviour.stateMachine);
				if (mStateMachine != null) {
					ActiveStateMachine = mStateMachine;
					ActiveGameObject = ActiveStateMachine.behaviour.gameObject;
					
				}
			} else {
				if(ActiveGameObject != null){
					StateMachineBehaviour behaviour=ActiveGameObject.GetComponent<StateMachineBehaviour>();
					if(behaviour != null){
						StateMachine mStateMachine = ((EditorApplication.isPlaying && !EditorApplication.isPaused) ? behaviour.executingStateMachine : behaviour.stateMachine);
						if (mStateMachine != null) {
							ActiveStateMachine=mStateMachine;
						}
					}
				}
			}
			StateMachineWindow.RepaintAll();
		}

		public void CenterView(){
			if (ActiveStateMachine == null) {
				return;			
			}
			Vector2 scrollTo = Vector2.zero;
			foreach(State state in ActiveStateMachine.states){
				scrollTo+=new Vector2(state.position.center.x-graphRect.width*0.5f,state.position.center.y-graphRect.height*0.5f);
			}	
			scrollTo/=ActiveStateMachine.states.Count;
			scrollPosition = scrollTo;
			StateMachineWindow.RepaintAll();
		}
		
		public void UpdateSelection(){
			transitionIndex = 0;
			if (PreferencesEditor.GetBool(Preference.CustomInspector)) {
				selectedStates.RemoveAll(x=>x==null);
				StateMachineWindow.CustomInspector.SelectedStates=selectedStates;
			} else {
				Selection.objects = selectedStates.ToArray();				
			}
			StateMachineWindow.RepaintAll ();
		}

		public void StartTransition(State state){
			connectionIndex = ActiveStateMachine.states.FindIndex (x => x == state);
			eventMode=EventMode.Connect;
		}

		private void DoStates (){
			if (ActiveStateMachine == null) {
				return;			
			}
			DoTransitions ();
			foreach (State state in ActiveStateMachine.states) {
				if(!selectedStates.Contains(state)){
					DrawState (state);
				}
			}
			foreach (State state in selectedStates) {
				DrawState (state);
			}
			SelectStates ();
			DragStates ();
		}
		
		private void DrawState (State state)
		{
			if (state != null) {
				GUI.Box (state.position, state.name, FsmStyles.GetNodeStyle(state.isDefaultState ?FsmStyles.Color.Orange : state.GetType () == typeof(AnyState) ? FsmStyles.Color.Aqua: (FsmStyles.Color)state.color,selectedStates.Contains(state),false));
				if(!ValidateState(state) && Event.current.type != EventType.Layout){
					GUI.Box(state.position,EditorGUIUtility.FindTexture ("console.warnicon"),"label");
				}
				DebugState(state);
				if(PreferencesEditor.GetBool(Preference.ShowStateDescription)){
					GUILayout.BeginArea(new Rect(state.position.x,state.position.y+state.position.height,state.position.width,500));
					GUILayout.Label(state.description,FsmStyles.WrappedLabel);
					GUILayout.EndArea();
				}

				StateMachineGUI.StateContextMenu(state,this);
			}
		}

		public void Update () {
			if (EditorApplication.isPlaying) {
				debugProgress += Time.deltaTime * 30;
				if (debugProgress > 142) {
					debugProgress = 0;
				}
				StateMachineWindow.RepaintAll();
			}
		}

		private bool ValidateState(State state){
			if (state == null) {
				return false;			
			}
			if (state.actions != null) {
				foreach (StateAction action in state.actions) {
					if(!(action is GetProperty || action is SetProperty)){
						
						FieldInfo[] fields = action.GetType ().GetFields (BindingFlags.Instance | BindingFlags.Public);
						for (int i=0; i< fields.Length; i++) {
							if (fields [i].FieldType.IsSubclassOf (typeof(NamedParameter))) {
								NamedParameter parameter = (NamedParameter)fields [i].GetValue (action);
								if (parameter != null && !parameter.IsConstant && fields [i].IsFieldRequired () && parameter.Reference == fields [i].GetDefaultReference().ToString()) {
									bool hideInInspector=false;
									foreach(object attr in fields[i].GetCustomAttributes(true)){
										if(attr.GetType() == typeof(HideInInspector)){
											hideInInspector=true;
										}
										
									}
									return hideInInspector;
								}
							}
						}
					}
				}
			}
			if ( state.transitions != null && state.transitions.Count > transitionIndex && state.transitions[transitionIndex].conditions != null) {
				foreach (StateCondition condition in state.transitions[transitionIndex].conditions) {
					FieldInfo[] fields = condition.GetType ().GetFields (BindingFlags.Instance | BindingFlags.Public);
					for (int i=0; i< fields.Length; i++) {
						if (fields [i].FieldType.IsSubclassOf (typeof(NamedParameter))) {
							NamedParameter parameter = (NamedParameter)fields [i].GetValue (condition);
							if (parameter!= null && !parameter.IsConstant && fields [i].IsFieldRequired () && parameter.Reference == fields [i].GetDefaultReference().ToString()) {
								bool hideInInspector=false;
								foreach(object attr in fields[i].GetCustomAttributes(true)){
									if(attr.GetType() == typeof(HideInInspector)){
										hideInInspector=true;
									}
									
								}
								
								return hideInInspector;
							}
						}
					}		
				}
			}
			return true;
		}

		private State debugState;
		private float debugProgress;
		private void DebugState(State state){
			
			State currentState = (ActiveStateMachine.behaviour != null) ? ActiveStateMachine.behaviour.currentState : null;
			if (currentState != null && EditorApplication.isPlaying && state.id==currentState.id) {
				if(debugState == null || debugState.id != state.id){
					debugProgress=0;
					debugState=state;
				}
				GUI.Box(new Rect(state.position.x+5,state.position.y+20,debugProgress,5),"", "MeLivePlayBar");
			}		
		}

		private void DragStates(){
			
			int controlID = GUIUtility.GetControlID( GUIControl.GetID (Control.DragStates),FocusType.Passive);
			Event ev = Event.current;
			if (ev.button != 0){
				return;
			}
			switch (ev.rawType) {
			case EventType.mouseDown:
				if(!graphRect.Contains(new Vector2(ev.mousePosition.x-scrollPosition.x,ev.mousePosition.y-scrollPosition.y))){
					return;
				}
				GUIUtility.hotControl = controlID;
				ev.Use();
				break;
			case EventType.mouseUp:
				
				if (GUIUtility.hotControl == controlID)
				{
					GUIUtility.hotControl = 0;
					ev.Use();
				}
				break;
			case EventType.mouseDrag:
				if (GUIUtility.hotControl == controlID)
				{
					foreach (State state in selectedStates) {
						state.position.x += Event.current.delta.x;
						state.position.y += Event.current.delta.y;
						
					}
					ev.Use();
				}
				break;
			}
			if (GUIUtility.hotControl == controlID) {
				AutoPan (1.0f);
			}
		}
		
		private void DoTransitions(){
			if (eventMode== EventMode.Connect && ActiveStateMachine.states.Count > connectionIndex) {
				DrawConnection (ActiveStateMachine.states [connectionIndex].position.center, Event.current.mousePosition, Color.green,1,false);
				StateMachineWindow.RepaintAll();
			}
			if (Event.current.type == EventType.Repaint) {
				foreach (State node in ActiveStateMachine.states) {
					if (node.transitions != null) {
						State prevState=null;
						foreach (StateTransition target in node.transitions) {
							if(target.toState != prevState){
								DoTransition(target,HasMultipleTransitions(node,target),(selectedStates.Count>0 && ActiveStateMachine.states.Find (x => x == node) == selectedStates[0] && node.transitions[transitionIndex].toState == target.toState ? Color.cyan : Color.white));
								prevState=target.toState;
							}
						}
					}
				}
			}
		}
		
		private void DoTransition(StateTransition target, bool hasMultiple,Color color){
			if(target != null && transitionIndex >=0){
				if(target.toState != null && target.fromState != null){
					bool doOffset=target.toState.transitions != null && target.toState.transitions.Find(x=>x.toState ==target.fromState)!= null;
					DrawConnection (target.fromState.position.center,target.toState.position.center,color,(hasMultiple?3:1),doOffset);
				}
			}
		}
		
		private bool HasMultipleTransitions(State state,StateTransition tr){
			foreach (StateTransition transition in state.transitions) {
				List<StateTransition> m=state.transitions.FindAll(x=>x.toState== transition.toState);
				if(m.Count>1 && transition==tr){
					return true;
				}
				
			}
			return false;
		}


		private void AutoPan (float speed)
		{
			if (Event.current.type != EventType.Repaint) {
				return;			
			}
			if (Event.current.mousePosition.x > graphRect.width + scrollPosition.x - 50) {
				offset.x -= speed;
				scrollPosition.x += speed;
				foreach (State state in selectedStates) {
					state.position.x += speed;
				}
				StateMachineWindow.RepaintAll ();
			}
			
			if ((Event.current.mousePosition.x < scrollPosition.x + 50) && scrollPosition.x > 0) {
				offset.x += speed;
				scrollPosition.x -= speed;
				foreach (State state in selectedStates) {
					state.position.x -= speed;
				}
				StateMachineWindow.RepaintAll ();
			}
			
			if (Event.current.mousePosition.y > graphRect.height + scrollPosition.y - 50) {
				offset.y -= speed;
				scrollPosition.y += speed;
				foreach (State state in selectedStates) {
					state.position.y += speed;
				}
				StateMachineWindow.RepaintAll ();
			}
			
			if ((Event.current.mousePosition.y < scrollPosition.y + 50) && scrollPosition.y > 0) {
				offset.y += speed;
				scrollPosition.y -= speed;
				foreach (State state in selectedStates) {
					state.position.y -= speed;
				}
				StateMachineWindow.RepaintAll ();
			}
		}

		private void SelectStates(){
			int controlID = GUIUtility.GetControlID(GUIControl.GetID (Control.SelectStates),FocusType.Passive);
			
			Event ev = Event.current;
			if (ev.button != 0) {
				return;			
			} 

			switch (ev.rawType) {
			case EventType.mouseDown:
				if(!graphRect.Contains(new Vector2(ev.mousePosition.x-scrollPosition.x,ev.mousePosition.y-scrollPosition.y))){
					return;
				}
				foreach (State state in ActiveStateMachine.states) {
					if (ev.button == 0 && state.position.Contains (ev.mousePosition)) {
						if(eventMode == EventMode.Connect){
							StateMachineUtility.MakeTransition(ActiveStateMachine.states[connectionIndex] ,state,ActiveStateMachine);
							eventMode=EventMode.None;
							MouseInstruction.Clear();
						}else{
							if(eventMode==EventMode.MakeTransition){
								connectionIndex = ActiveStateMachine.states.FindIndex (x => x == state);
								eventMode=EventMode.Connect;
								MouseInstruction.Set("Select a state you want to transition to.");
							}
							
							if (EditorGUI.actionKey || ev.shift) {
								if (!this.selectedStates.Contains (state)) {
									this.selectedStates.Add (state);
								} else {
									this.selectedStates.Remove (state);
								}
								ev.Use ();
							} else {
								if (!this.selectedStates.Contains (state)) {
									this.selectedStates.Clear ();
									this.selectedStates.Add (state);
								}
								HandleUtility.Repaint ();
							}
							UpdateSelection();
							GUIUtility.hotControl=0;

							GUIUtility.keyboardControl = 0;
						}
						return;
					} 		
				}

				MouseInstruction.Clear();
				GUIUtility.hotControl = controlID;
				selectionStartPoint=ev.mousePosition;
				if (!EditorGUI.actionKey && !ev.shift)
				{
					this.selectedStates.Clear();
				}
				eventMode=EventMode.Pick;
				UpdateSelection();
				ev.Use();
				break;
			case EventType.mouseUp:
				if(!graphRect.Contains(new Vector2(ev.mousePosition.x-scrollPosition.x,ev.mousePosition.y-scrollPosition.y))){
					eventMode=EventMode.None;
					StateMachineWindow.RepaintAll();
					return;
				}
				if (GUIUtility.hotControl == controlID)
				{
					if(eventMode == EventMode.Pick && ev.control){
						StateMachineUtility.CreateState(Event.current.mousePosition,ActiveStateMachine);
					}
					GUIUtility.hotControl = 0;
					eventMode=EventMode.None;
					ev.Use();
				}
				break;
			case EventType.mouseDrag:
				if (GUIUtility.hotControl == controlID && (eventMode == EventMode.Pick || eventMode==EventMode.Rect))
				{
					eventMode=EventMode.Rect;
					SelectStatesInRect(FromToRect(selectionStartPoint, ev.mousePosition));
					ev.Use();
				}
				break;
			case EventType.Repaint:
				if (GUIUtility.hotControl == controlID && eventMode == EventMode.Rect)
				{
					((GUIStyle)"SelectionRect").Draw(FromToRect(this.selectionStartPoint, ev.mousePosition), false, false, false, false);
				}
				break;
			}
		}
		
		private void SelectStatesInRect(Rect r)
		{
			foreach (State state in ActiveStateMachine.states)
			{
				Rect rect = state.position;
				if (rect.xMax < r.x || rect.x > r.xMax || rect.yMax < r.y || rect.y > r.yMax)
				{
					selectedStates.Remove(state);
					continue;
				}
				if(!selectedStates.Contains(state)){
					this.selectedStates.Add(state);
				}
			}

			UpdateSelection ();
		}
		
		private Rect FromToRect(Vector2 start, Vector2 end)
		{
			Rect rect = new Rect(start.x, start.y, end.x - start.x, end.y - start.y);
			if (rect.width < 0f)
			{
				rect.x = rect.x + rect.width;
				rect.width = -rect.width;
			}
			if (rect.height < 0f)
			{
				rect.y = rect.y + rect.height;
				rect.height = -rect.height;
			}
			return rect;
		}
	
		
		public enum EventMode{
			None,
			Pick,
			Rect,
			Connect,
			MakeTransition
		}
	}
}