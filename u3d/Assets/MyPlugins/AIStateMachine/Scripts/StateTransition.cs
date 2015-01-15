using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StateMachine.Condition;

namespace StateMachine{
	[System.Serializable]
	public class StateTransition:Node {
		public State fromState;
		public State toState;
		public bool mute;
		public List<StateCondition> conditions;

		public void Initialize(StateMachine stateMachine){
			for (int i=0; i< conditions.Count; i++) {
				conditions[i].Initialize(stateMachine);
			}
		}

		private void OnEnable(){
			hideFlags = HideFlags.HideInHierarchy;
			if (conditions == null) {
				conditions= new List<StateCondition>();			
			}
		}

		public void DoEnter(){
			int count = conditions.Count;
			for(int i=0;i< count;i++) {
				conditions[i].OnEnter();
			}
		}

		public void DoExit(){
			int count = conditions.Count;
			for(int i=0;i< count;i++) {
				conditions[i].OnExit();
			}
		}

		public State Validate(){
			if (mute) {
				return null;		
			}
			int count = conditions.Count;
			for(int i=0;i< count;i++) {
				if(conditions[i].enabled && !conditions[i].Validate()){
					return null;
				}
			}
			return toState;
		}

		public void DeleteTransition(){
			DeleteConditions ();
			DestroyImmediate (this, true);
		}

		public void DeleteConditions(){
			if (conditions != null) {
				foreach (StateCondition condition in conditions) {
					condition.DeleteConditon ();			
				}
				conditions.Clear ();
			}
		}
	}
}