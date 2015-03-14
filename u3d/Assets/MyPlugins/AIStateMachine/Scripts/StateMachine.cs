using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StateMachine.Action;
using System.Reflection;
using StateMachine.Condition;
using System;

namespace StateMachine{
	[System.Serializable]
	public class StateMachine : ScriptableObject {
		public List<NamedParameter> parameters;
		public List<State> states;
		[System.NonSerialized]
		public GameObject owner;
		[System.NonSerialized]
		public StateMachineBehaviour behaviour;
		public string description;
		public StateMachine root;
		public List<StateMachine> layers;
		public int layer = 0;
		public bool enabled=true;

		private void OnEnable(){
			if (states == null) {
				states = new List<State> ();
			}
			if (parameters == null) {
				parameters= new List<NamedParameter>();			
			}
			if (root == null) {
				root=this;			
			}
			if (layers == null) {
				layers= new List<StateMachine>();
			}
		}

		public void Initialize(StateMachineBehaviour behaviour){
			this.owner = behaviour.gameObject;
			this.behaviour = behaviour;
			for (int i=0; i< states.Count; i++) {
				states [i].Initialize (this);
			}

		}
		
		public NamedParameter GetPrameter(string name){
			int count = parameters.Count;
			for (int i=0; i<count; i++) {
				if(parameters[i].Name.Equals(name)){
					return parameters[i];
				}			
			}
			return null;
		}


		public void SetParameter(string name, object value, bool createIfNull){
			NamedParameter parameter = GetPrameter (name);
			if (parameter == null && createIfNull) {
				if (createIfNull) {
					parameter = (NamedParameter)ScriptableObject.CreateInstance (value.GetType ().GetParameterType ());
					parameter.GetType ().GetProperty ("Value").SetValue (parameter, value, null);
					parameter.Name = name;
					parameter.stateMachine = this;
					this.parameters.Add (parameter);
				}
				
			} else {
				SetParameter (name, value);
			}
		}

		public void SetParameter(string name, object value){
			NamedParameter parameter = GetPrameter (name);
			if (parameter == null) {
				//Debug.Log("Could not set parameter "+name+"! Skipping.");
				return;
			}
			if (parameter.GetType () == typeof(FloatParameter)) {
				(parameter as FloatParameter).Value = (float)value;		
			} else if (parameter.GetType () == typeof(IntParameter)) {
				(parameter as IntParameter).Value = (int)value;			
			} else if (parameter.GetType () == typeof(BoolParameter)) {
				(parameter as BoolParameter).Value = (bool)value;	
			} else if (parameter.GetType () == typeof(ColorParameter)) {
				(parameter as ColorParameter).Value = (Color)value;	
			} else if (parameter.GetType () == typeof(ObjectParameter)) {
				(parameter as ObjectParameter).Value = (UnityEngine.Object)value;	
			} else if (parameter.GetType () == typeof(StringParameter)) {
				(parameter as StringParameter).Value = (string)value;	
			} else if (parameter.GetType () == typeof(Vector2Parameter)) {
				(parameter as Vector2Parameter).Value = (Vector2)value;	
			} else if (parameter.GetType () == typeof(Vector3Parameter)) {
				(parameter as Vector3Parameter).Value = (Vector3)value;	
			} else if (parameter.GetType () == typeof(List<>)) {
				(parameter as ListParameter).Value = (List<object>)value;

			} else if (parameter.GetType () == typeof(SystemObjectParameter)) {
				(parameter as SystemObjectParameter).Value = value;
			}
		}

		
		private static IList MakeList(Type t)
		{
			var listType = typeof(List<>);
			var constructedListType = listType.MakeGenericType(t);
			var instance = Activator.CreateInstance(constructedListType);
			return (IList)instance;
		}


		public static void Copy(StateMachine from,StateMachine to,bool parent){
			to.DeleteStates ();
			to.DeleteParameters ();

			from.parameters.RemoveAll (x => x == null);
			for (int i=0; i<from.parameters.Count; i++) {
				NamedParameter parameter = (NamedParameter)ScriptableObject.Instantiate (from.parameters [i]);
				parameter.stateMachine = to;
				to.parameters.Add (parameter);
				#if UNITY_EDITOR
				if (parent) {
					UnityEditor.AssetDatabase.AddObjectToAsset (parameter, to);
					UnityEditor.AssetDatabase.SaveAssets ();
				}
				#endif
			}
		
			from.states.RemoveAll (x => x == null);

			for(int i=0;i< from.states.Count;i++){
				State state =(State)ScriptableObject.Instantiate(from.states[i]);
				state.name=state.name.Replace("(Clone)","");
				state.actions.Clear();
				state.transitions.Clear();
				to.states.Add(state);
				#if UNITY_EDITOR
				if(parent){
					UnityEditor.AssetDatabase.AddObjectToAsset(state,to);
					UnityEditor.AssetDatabase.SaveAssets();
				}
				#endif
				from.states[i].actions.RemoveAll(x=>x==null);
				for (int a=0; a< from.states[i].actions.Count; a++) {
					StateAction action = (StateAction)ScriptableObject.Instantiate (from.states[i].actions[a]);
					action.name=action.name.Replace("(Clone)","");
					state.actions.Add(action);
					#if UNITY_EDITOR
					if(parent){
						UnityEditor.AssetDatabase.AddObjectToAsset(action,state);
						UnityEditor.AssetDatabase.SaveAssets();
					}
					#endif
					
					FieldInfo[] fields =action.GetType().GetFields ();
					for (int af=0; af< fields.Length; af++) {
						if(fields[af].FieldType.IsSubclassOf(typeof(NamedParameter))){
							NamedParameter mParameter=(NamedParameter)fields[af].GetValue(action);
							if(mParameter == null){
								mParameter=(NamedParameter)ScriptableObject.CreateInstance(fields[af].FieldType);
							}
							NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate(mParameter);
							paramter.stateMachine=to;
							if(paramter.Reference == DefaultReference.Owner.ToString()){
								(paramter as ObjectParameter).Value=to.owner;
							}
							if(paramter.Reference == DefaultReference.None.ToString()){
								paramter.isNone=true;
							}
							#if UNITY_EDITOR
							if(parent){
								UnityEditor.AssetDatabase.AddObjectToAsset(paramter,action);
								UnityEditor.AssetDatabase.SaveAssets();
							}
							#endif
							fields[af].SetValue(action,paramter);
						}
						
					}
				}

				from.states[i].transitions.RemoveAll(x=>x==null);
				for (int t=0; t< from.states[i].transitions.Count; t++) {
					StateTransition transition = (StateTransition)ScriptableObject.Instantiate (from.states[i].transitions [t]);
					transition.name=transition.name.Replace("(Clone)","");
					transition.conditions.Clear();
					state.transitions.Add(transition);
					#if UNITY_EDITOR
					if(parent){
						UnityEditor.AssetDatabase.AddObjectToAsset(transition,state);
						UnityEditor.AssetDatabase.SaveAssets();
					}
					#endif
					from.states[i].transitions[t].conditions.RemoveAll(x=>x==null);
					for(int c=0; c<from.states[i].transitions[t].conditions.Count;c++){

						StateCondition condition=(StateCondition)ScriptableObject.Instantiate(from.states[i].transitions[t].conditions[c]);
						condition.name=condition.name.Replace("(Clone)","");
						transition.conditions.Add(condition);
						#if UNITY_EDITOR
						if(parent){
							UnityEditor.AssetDatabase.AddObjectToAsset(condition,transition);
							UnityEditor.AssetDatabase.SaveAssets();
						}
						#endif
						
						FieldInfo[] fields =condition.GetType().GetFields ();
						
						for (int af=0; af< fields.Length; af++) {
							if(fields[af].FieldType.IsSubclassOf(typeof(NamedParameter))){
								UnityEngine.Object mParameter=(UnityEngine.Object)fields[af].GetValue(condition);
								if(mParameter == null){
									mParameter=(NamedParameter)ScriptableObject.CreateInstance(fields[af].FieldType);
								}
								
								NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate(mParameter);
								paramter.stateMachine=to;
								if(paramter.Reference == DefaultReference.Owner.ToString()){
									(paramter as ObjectParameter).Value=to.owner;
								}
								if(paramter.Reference == DefaultReference.None.ToString()){
									paramter.isNone=true;
								}
								#if UNITY_EDITOR
								if(parent){
									UnityEditor.AssetDatabase.AddObjectToAsset(paramter,condition);
									UnityEditor.AssetDatabase.SaveAssets();
								}
								#endif
								fields[af].SetValue(condition,paramter);
								
							}		
						}
					}
				}
			}

			for (int i=0; i< to.states.Count; i++) {
				if (to.states [i].transitions.Count > 0) {
					for (int t=0; t< to.states[i].transitions.Count; t++) {
						to.states [i].transitions [t].fromState = to.states.Find (x => x != null&& x.id == from.states [i].transitions [t].fromState.id);
						to.states [i].transitions [t].toState = to.states.Find (x => x!= null && x.id == from.states [i].transitions [t].toState.id);
						
					}
				}
			}

		}


		public void DeleteParameters(){
			if (parameters != null) {
				foreach (NamedParameter paramter in parameters) {
					DestroyImmediate (paramter, true);
				}
				parameters.Clear ();
			}
		}

		public void DeleteStates(){
			if (states != null) {
				foreach (State state in states) {
					state.DeleteState ();		
				}
				states.Clear ();
			}
		}
	}
}