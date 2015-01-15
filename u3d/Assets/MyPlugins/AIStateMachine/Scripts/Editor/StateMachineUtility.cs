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
	public static class StateMachineUtility  {
		#region StateMachine
		/// <summary>
		/// Creates a new state machine.
		/// </summary>
		/// <returns>The state machine.</returns>
		/// <param name="displayFilePanel">If set to true, it will give you a path file panel selection.</param>
		public static StateMachine CreateStateMachine(bool displayFilePanel){
			StateMachine stateMachine=	AssetCreator.CreateAsset<StateMachine>(displayFilePanel);
			CreateAnyState(new Vector2(GraphEditor.MaxCanvasSize,GraphEditor.MaxCanvasSize)*0.5f,stateMachine);
			return stateMachine;
		}

		/// <summary>
		/// Adds the state machine to a game object.
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		/// <param name="stateMachine">State machine.</param>
		public static void AddStateMachine(GameObject gameObject, StateMachine stateMachine){
			StateMachineBehaviour behaviour=gameObject.AddComponent<StateMachineBehaviour>();
			behaviour.stateMachine=stateMachine;
		}
		#endregion

		#region State
		/// <summary>
		/// Creates AnyState in the sate machine at the given position.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="stateMachine">State machine.</param>
		public static void CreateAnyState(Vector2 position, StateMachine stateMachine){
			if (stateMachine == null) {
				return;			
			}
			RecordUndo (stateMachine);
			AnyState anyState = ScriptableObject.CreateInstance<AnyState> ();
			anyState.id = Guid.NewGuid ().ToString();
			anyState.position = new Rect (position.x,position.y, State.kNodeWidth, State.kNodeHeight);
			anyState.name="Any State";
			if(EditorUtility.IsPersistent(stateMachine)){
				AssetDatabase.AddObjectToAsset (anyState, stateMachine);
			}
			AssetDatabase.SaveAssets ();
			stateMachine.states.Add (anyState);
		}

		/// <summary>
		/// Creates a state at a given position
		/// </summary>
		/// <returns>The created state.</returns>
		/// <param name="position">Position.</param>
		/// <param name="stateMachine">State machine.</param>
		public static State CreateState(Vector2 position,StateMachine stateMachine){
			if (stateMachine == null) {
				return null;			
			}
			RecordUndo (stateMachine);
			State state = ScriptableObject.CreateInstance<State> ();
			state.id = Guid.NewGuid ().ToString();
			state.position = new Rect (position.x, position.y, State.kNodeWidth, State.kNodeHeight);
			state.name="New State";
			if (EditorUtility.IsPersistent (stateMachine)) {
				AssetDatabase.AddObjectToAsset (state, stateMachine);
			}
			AssetDatabase.SaveAssets ();
			
			if (stateMachine.states.Count == 1) {
				SetAsDefaultState (state,stateMachine);			
			}
			stateMachine.states.Add (state);
			return state;
		}

		/// <summary>
		/// Sets the state of the state machine as a starting state.
		/// </summary>
		/// <param name="state">State.</param>
		/// <param name="stateMachine">State machine.</param>
		public static void SetAsDefaultState(State state, StateMachine stateMachine){
			if (stateMachine == null) {
				return;			
			}
			RecordUndo (stateMachine);
			stateMachine.states.ForEach(x=>x.isDefaultState=false);
			state.isDefaultState = true;
		}

		/// <summary>
		/// Removes the state from the given state machine.
		/// </summary>
		/// <param name="state">State.</param>
		/// <param name="stateMachine">State machine.</param>
		public static void DeleteState(State state, StateMachine stateMachine){
			if (stateMachine == null) {
				return;			
			}
			if(state.GetType() == typeof(AnyState)){
				Debug.Log("You can't delete AnyState.");
				return;
			}
			RecordUndo (stateMachine);
			if (state.isDefaultState && stateMachine.states.Count > 2) {
				stateMachine.states.Find(x=> x.isDefaultState == false && x.GetType()!=typeof(AnyState)).isDefaultState=true;
			}
			
			stateMachine.states.Remove (state);
			state.DeleteState ();
			CleanupTransitions (stateMachine);
			AssetDatabase.SaveAssets();
		}
		
		public static void CleanupTransitions(StateMachine stateMachine){
			if (stateMachine == null) {
				return;			
			}
			foreach (State mState in stateMachine.states) {
				if(mState.transitions != null){
					mState.transitions.Where(x=>x.toState==null).ToList().ForEach(y=>{y.fromState.transitions.Remove(y);y.DeleteTransition();}); 
					
				}
			}
			AssetDatabase.SaveAssets();
		}
		#endregion

		#region Parameter
		/// <summary>
		/// Creates a new local parameter.
		/// </summary>
		/// <param name="type">Type.</param>
		/// <param name="stateMachine">State machine.</param>
		public static void CreateParameter(Type type,StateMachine stateMachine){
			if (stateMachine == null) {
				return;			
			}
			RecordUndo (stateMachine);
			NamedParameter parameter = (NamedParameter)ScriptableObject.CreateInstance (type);
			parameter.Name ="New "+ type.ToString ().Split('.').Last().Replace("Parameter","");
			parameter.name = type.ToString ();
			if (EditorUtility.IsPersistent (stateMachine)) {
				AssetDatabase.AddObjectToAsset (parameter, stateMachine);
			}
			stateMachine.parameters.Add (parameter);
			AssetDatabase.SaveAssets();
			EditorUtility.SetDirty (stateMachine);
			EditorPrefs.SetBool("Parameters",true);	
		}

		/// <summary>
		/// Gives you a menu with all availible parameter types and adds the selected parameter to the
		/// state machine
		/// </summary>
		/// <param name="stateMachine">State machine.</param>
		public static void AddParameter(StateMachine stateMachine){
			GenericMenu genericMenu = new GenericMenu ();
			IEnumerable<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(NamedParameter)));
			foreach(Type type in types){
				Type mType=type;
				genericMenu.AddItem (new GUIContent (type.ToString().Split('.').Last().Replace("Parameter","")), false, delegate() {
					StateMachineUtility.CreateParameter(mType,stateMachine);
				});
				
			}
			genericMenu.ShowAsContext ();
			Event.current.Use();
		}

		/// <summary>
		/// Removes the local parameter from the state machine.
		/// </summary>
		/// <param name="parameter">Parameter.</param>
		/// <param name="stateMachine">State machine.</param>
		public static void RemoveParameter(NamedParameter parameter, StateMachine stateMachine){
			StateMachineUtility.RecordUndo(stateMachine);
			UnityEngine.Object.DestroyImmediate(parameter,true);
			stateMachine.parameters.Remove(parameter);
			AssetDatabase.SaveAssets();
		}
		#endregion

		#region Transition
		/// <summary>
		/// Makes a transition from a given state to a state in the state machine.
		/// </summary>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="stateMachine">State machine.</param>
		public static void MakeTransition(State from, State to, StateMachine stateMachine){
			if (stateMachine == null) {
				return;			
			}
			if(to.GetType() == typeof(AnyState)){
				Debug.Log("AnyState is running parallel. You can not make a transition to it.");
				return;
			}
			if (from == to) {
				return;			
			}

			RecordUndo (stateMachine);
			StateTransition transition = ScriptableObject.CreateInstance<StateTransition>();
			transition.fromState = from;
			transition.toState=to;
			transition.name=transition.fromState.name +" -> "+transition.fromState.name;
			if (EditorUtility.IsPersistent (stateMachine)) {
				AssetDatabase.AddObjectToAsset (transition, transition.fromState);
			}
			AssetDatabase.SaveAssets();
			transition.fromState.transitions.Add(transition);
		}

		/// <summary>
		/// Removes a transition from the state.
		/// </summary>
		/// <param name="state">State.</param>
		/// <param name="transition">Transition.</param>
		public static void RemoveTransition(State state, StateTransition transition){
			transition.DeleteTransition ();
			state.transitions.Remove (transition);
			AssetDatabase.SaveAssets();
		}
	
		#endregion

		#region Node
		/// <summary>
		/// Removes an Action or Condition from the state.
		/// </summary>
		/// <param name="state">State.</param>
		/// <param name="node">Node.</param>
		public static void RemoveNode(State state,Node node){
			if (node is StateAction) {
				RemoveAction (state, node as StateAction);			
			} else if (node is StateCondition) {
				RemoveCondition(state.transitions[StateMachineWindow.StateMachineEditor.transitionIndex],node as StateCondition);
			}
		}

		/// <summary>
		/// Creates node paramters
		/// </summary>
		/// <param name="node">Node.</param>
		public static void CreateNodeParameters(Node node){
			FieldInfo[] fields = node.GetType().GetFields ();

			for (int i=0; i< fields.Length; i++) {
				if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
					NamedParameter paramter=(NamedParameter)ScriptableObject.CreateInstance(fields[i].FieldType);
					paramter.name=fields[i].Name;
					fields[i].SetValue(node,paramter);
					if(fields[i].GetDefaultValue() != null){
						paramter.GetType().GetProperty("Value").SetValue(paramter,fields[i].GetDefaultValue(),null);
					}
					if (EditorUtility.IsPersistent (node)) {
						AssetDatabase.AddObjectToAsset (paramter, node);
					}
					AssetDatabase.SaveAssets();
				}		
			}		
		}

		/// <summary>
		/// Deletes node parameters.
		/// </summary>
		/// <param name="node">Node.</param>
		public static void DeleteNodeParameters(Node node){
			FieldInfo[] fields = node.GetType().GetFields ();
			for (int i=0; i< fields.Length; i++) {
				if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
					UnityEngine.Object.DestroyImmediate((UnityEngine.Object)fields[i].GetValue(node),true);
				}		
			}
		}
		#endregion

		#region Action
		/// <summary>
		/// Gives you a menu with all availible action types and adds the selected action to the state machine.
		/// </summary>
		/// <param name="state">State.</param>
		public static void AddAction(State state){
			GenericMenu genericMenu = new GenericMenu ();
			IEnumerable<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(StateAction)));
			foreach(Type type in types){
				Type actionType=type;
				genericMenu.AddItem (new GUIContent (type.GetCategory()+"/" + type.ToString().Split('.').Last()), false,delegate() {
					StateMachineUtility.CreateAction(state,actionType);
				});
			}
			genericMenu.ShowAsContext ();
		}

		/// <summary>
		/// Creates the action of type and adds it to the state.
		/// </summary>
		/// <param name="state">State.</param>
		/// <param name="type">Type.</param>
		public static void CreateAction(State state,Type type){
			if (!type.IsSubclassOf (typeof(StateAction)) || state == null) {
				return;			
			}

			StateAction action = (StateAction)ScriptableObject.CreateInstance(type);
			RecordUndoSimple (state, action,"Create Action");
			action.name = type.GetCategory () + "." + type.ToString ().Split ('.').Last ();
			if (EditorUtility.IsPersistent (state)) {
				AssetDatabase.AddObjectToAsset (action, state);
			}
			AssetDatabase.SaveAssets();
			
			state.actions.Add(action);
			StateMachineUtility.CreateNodeParameters (action);
		}


		/// <summary>
		/// Removes the action from the state.
		/// </summary>
		/// <param name="state">State.</param>
		/// <param name="action">Action.</param>
		public static void RemoveAction(State state,StateAction action){
			if (state == null) {
				return;			
			}
			RecordUndoSimple (state, action,"Action Delete");
			state.actions.Remove (action);
			StateMachineUtility.DeleteNodeParameters (action);
			UnityEngine.Object.DestroyImmediate (action, true);
			AssetDatabase.SaveAssets ();
		}
		#endregion

		#region Condition
		/// <summary>
		/// Gives you a menu to all availible conditions and adds the selected to the transition.
		/// </summary>
		/// <param name="transition">Transition.</param>
		public static void AddCondition(StateTransition transition){
			GenericMenu genericMenu = new GenericMenu ();
			IEnumerable<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(StateCondition)));
			foreach(Type type in types){
				Type mType=type;
				genericMenu.AddItem (new GUIContent (type.GetCategory()+"/" + type.ToString().Split('.').Last()), false, delegate() {
					StateMachineUtility.CreateCondition(transition,mType);
				});
			}
			genericMenu.ShowAsContext ();
		}

		/// <summary>
		/// Creates and add the condition of type to the transition. 
		/// </summary>
		/// <param name="transition">Transition.</param>
		/// <param name="type">Type.</param>
		public static void CreateCondition(StateTransition transition, Type type){
			if (!type.IsSubclassOf (typeof(StateCondition)) || transition == null) {
				return;			
			}
			StateCondition condition = (StateCondition)ScriptableObject.CreateInstance(type);	
			condition.name = type.GetCategory () + "." + type.ToString ().Split ('.').Last ();

			if (EditorUtility.IsPersistent (transition)) {
				AssetDatabase.AddObjectToAsset (condition, transition);
			}
			AssetDatabase.SaveAssets();

			transition.conditions.Add(condition);
			StateMachineUtility.CreateNodeParameters (condition);
		}

		/// <summary>
		/// Removes the condition from the transition.
		/// </summary>
		/// <param name="transition">Transition.</param>
		/// <param name="condition">Condition.</param>
		public static void RemoveCondition(StateTransition transition,StateCondition condition){
			RecordUndoSimple (transition, condition,"Condition Delete");
			StateMachineUtility.DeleteNodeParameters (condition);
			UnityEngine.Object.DestroyImmediate(condition,true);
			transition.conditions.Remove (condition);
			AssetDatabase.SaveAssets();
		}
		#endregion

		#region Undo
		public static void RecordUndo(StateMachine stateMachine){
			if (stateMachine == null) {
				return;			
			}
			List<UnityEngine.Object> undoObjs = new List<UnityEngine.Object> ();
			undoObjs.Add (stateMachine);

			foreach(State state in stateMachine.states){
				undoObjs.Add(state);
				
				foreach(StateAction action in state.actions){
					undoObjs.Add(action);
					FieldInfo[] fields = action.GetType().GetFields ();
					for (int i=0; i< fields.Length; i++) {
						if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
							undoObjs.Add((UnityEngine.Object)fields[i].GetValue(action));
						}		
					}
				}
				
				foreach(StateTransition transition in state.transitions){
					undoObjs.Add(transition);
					
					foreach(StateCondition condition in transition.conditions){
						undoObjs.Add(condition);
						FieldInfo[] fields = condition.GetType().GetFields ();
						for (int i=0; i< fields.Length; i++) {
							if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
								undoObjs.Add((UnityEngine.Object)fields[i].GetValue(condition));
							}		
						}
					}
				}		
			}

			if (stateMachine.parameters != null) {
				foreach(NamedParameter paramter in stateMachine.parameters){
					undoObjs.Add(paramter);
				}	
			}
			undoObjs.RemoveAll (x => x == null);
			Undo.RegisterCompleteObjectUndo (undoObjs.ToArray (), "StateMachine");
		}

		private static void RecordUndoSimple(UnityEngine.Object obj, UnityEngine.Object obj2,string name){
			List<UnityEngine.Object> objs = new List<UnityEngine.Object> ();
			objs.Add (obj);
			objs.Add (obj2);
			FieldInfo[] fields = obj2.GetType().GetFields ();
			for (int i=0; i< fields.Length; i++) {
				if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
					objs.Add((UnityEngine.Object)fields[i].GetValue(obj2));
				}		
			}
			objs.RemoveAll (x => x == null);
			Undo.RegisterCompleteObjectUndo (objs.ToArray (), name);
		}
		#endregion

		#region Misc
		public static EventType ReserveEvent(params Rect[] areas){
			EventType eventType = Event.current.type;
			foreach(Rect area in areas){
				if((area.Contains(Event.current.mousePosition) && (eventType == EventType.MouseDown || eventType == EventType.ScrollWheel))){
					Event.current.type=EventType.Ignore;
				}
			}
			return eventType;
		}
		
		public static void ReleaseEvent(EventType type){
			if (Event.current.type != EventType.Used) {
				Event.current.type = type;
			}
		}
		#endregion
	}
}