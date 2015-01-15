using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace StateMachine.Action{
	[System.Serializable]
	public class StateAction : Node {
		protected StateMachine stateMachine;
		[System.NonSerialized]
		private bool finished=false;
		
		public void Initialize(StateMachine stateMachine){
			this.stateMachine = stateMachine;

			FieldInfo[] fields = GetType ().GetFields ();
			for (int i=0; i< fields.Length; i++) {
				if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
					NamedParameter mParameter =(NamedParameter)fields[i].GetValue(this);
					if(mParameter != null){
						mParameter.stateMachine=stateMachine;
					}
				}		
			}
		}



		private void OnEnable(){
			hideFlags = HideFlags.HideInHierarchy;
		}

		public virtual void OnEnter(){}
		
		public virtual void OnExit(){}
		
		public virtual void OnUpdate(){}

		public virtual void OnFixedUpdate(){}

		public virtual void OnAnimatorIK(int layer){}

		public virtual void OnAnimatorMove(){}

		public virtual void OnGUI(){}

		public void Finish(){
			finished = true;
		}

		public void Reset(){
			finished = false;
		}

		public bool IsFinished{
			get{
				return finished;
			}
		}

		public void DeleteAction(){
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