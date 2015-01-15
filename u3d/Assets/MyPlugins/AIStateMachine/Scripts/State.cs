using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using StateMachine.Action;

namespace StateMachine{
	[System.Serializable]
	public class State : ScriptableObject {
		public const float kNodeWidth = 150f;
		public const float kNodeHeight = 30f;
		public Rect position;
		public string id;
		public int color;
		public bool isDefaultState;
		public List<StateTransition> transitions;
		public List<StateAction> actions;
		public string description;

		public bool IsFinished{
			get{
				bool finished=true;
				for(int i=0;i< actions.Count;i++){
					StateAction action=actions[i];
					if(action.enabled && !action.IsFinished ){//&& action.CanFinish){
						finished=false;
					}
				}
				return finished;
			}
		}


		private void OnEnable(){
			hideFlags = HideFlags.HideInHierarchy;
			if (actions == null) {
				actions= new List<StateAction>();			
			}
			if (transitions == null) {
				transitions= new List<StateTransition>();			
			}
		}
		
		public void Initialize(StateMachine stateMachine){
			for (int i=0; i< actions.Count; i++) {
				actions[i].Initialize(stateMachine);
			}
			for (int i=0; i< transitions.Count; i++) {
				transitions[i].Initialize(stateMachine);
			}
		}
		
		public void DoEnter(){
			for(int i=0;i< actions.Count;i++){
				StateAction action=actions[i];
				if(action.enabled){
					action.OnEnter();	
				}
			}

			for (int i=0;i< transitions.Count;i++) {
				StateTransition transition=transitions[i];
				transition.DoEnter();		
			}
		}
		
		public void DoExit(){
			for(int i=0;i< actions.Count;i++){
				StateAction action=actions[i];
				action.Reset();
				action.OnExit();		
			}

			for (int i=0;i< transitions.Count;i++) {
				StateTransition transition=transitions[i];
				transition.DoExit();		
			}
		}
		
		public void DoUpdate(){
			for (int i=0; i< actions.Count; i++) {
				if(actions[i].enabled && !actions[i].IsFinished){
					actions[i].OnUpdate();	
				}
			}
		}

		public void DoFixedUpdate(){
			for (int i=0; i< actions.Count; i++) {
				if(actions[i].enabled && !actions[i].IsFinished){
					actions[i].OnFixedUpdate();	
				}
			}
		}

		public void DoOnAnimatorIK(int layer){
			for (int i=0; i< actions.Count; i++) {
				if(actions[i].enabled && !actions[i].IsFinished){
					actions[i].OnAnimatorIK(layer);	
				}
			}
		}

		public void DoAnimatorMove(){
			for (int i=0; i< actions.Count; i++) {
				if(actions[i].enabled && !actions[i].IsFinished){
					actions[i].OnAnimatorMove();	
				}
			}
		}

		public void DoOnGUI(){
			for (int i=0; i< actions.Count; i++) {
				if(actions[i].enabled && !actions[i].IsFinished){
					actions[i].OnGUI();	
				}
			}	
		}

		public State ValidateTransitions(){
			int count=transitions.Count;
			for(int i=0; i < count; i++) {
				State state = transitions[i].Validate();
				if(state != null){
					return state;
				}
			}
			return null;
		}

		public void DeleteState(){
			DeleteTransitions ();
			DeleteActions ();
			DestroyImmediate (this, true);
		}

		public void DeleteTransitions(){
			if (transitions != null) {
				for (int i=0;i< transitions.Count;i++) {
					StateTransition transition=transitions[i];
					transition.DeleteTransition ();			
				}		
				transitions.Clear ();
			}
		}

		public void DeleteActions(){
			if (actions != null) {
				for(int i=0;i< actions.Count;i++){
					StateAction action=actions[i];
					action.DeleteAction ();			
				}
				actions.Clear ();
			}
		}
	}	
}