using UnityEngine;
using System.Collections;

namespace StateMachine.Condition.UEvent{
	[Info (category = "",    
	       description = "Deprecated, do not use. Please use OnUnityEvent instead.",
	       url = "")]
	[System.Serializable]
	public class OnTriggerEnter2D : StateCondition {
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject to use.")]
		public ObjectParameter gameObject;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the other game object to use it in the next state.")]
		public ObjectParameter other;
		private UnityEventHandler handler;
		private bool isTrigger;
		
		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+gameObject.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}

			handler = ((GameObject)gameObject.Value).GetComponent<UnityEventHandler> ();
			if (handler == null) {
				handler = ((GameObject)gameObject.Value).AddComponent<UnityEventHandler>();	
			}
			handler.onTriggerEnter+=OnTrigger;
		}
		
		public override void OnExit ()
		{
			if (isTrigger) {
				handler.onTriggerEnter -= OnTrigger;
			}
			isTrigger = false;
		}
		
		private void OnTrigger(GameObject other){
			this.other.Value = other;
			isTrigger = true;
		}
		
		public override bool Validate ()
		{
			if (isTrigger) {
				isTrigger=false;	
				return true;
			}
			return isTrigger;
		}
	}
}