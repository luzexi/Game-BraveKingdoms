using UnityEngine;
using System.Collections;
using System.Reflection;

namespace StateMachine.Condition{
	[System.Serializable]
	public class StateCondition:Node {
		protected StateMachine stateMachine;

		public void Initialize(StateMachine stateMachine){
			this.stateMachine = stateMachine;	
			FieldInfo[] fields = GetType().GetFields ();
			for (int i=0; i< fields.Length; i++) {
				if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
					NamedParameter mParam=(NamedParameter)fields[i].GetValue(this);
					if(mParam != null){
						mParam.stateMachine=stateMachine;
					}
				}		
			}
		}

		private void OnEnable(){
			hideFlags = HideFlags.HideInHierarchy;
		}

		public virtual void OnEnter(){}

		public virtual void OnExit(){}

		public virtual bool Validate(){
			return false;
		}

		public void DeleteConditon(){
			FieldInfo[] fields = GetType().GetFields ();
			
			for (int i=0; i< fields.Length; i++) {
				if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
					DestroyImmediate((NamedParameter)fields[i].GetValue(this),true);
				}		
			}
			DestroyImmediate (this, true);		
		}
	}
}