using UnityEngine;
using System.Collections;

namespace StateMachine.Condition.UEvent{
	[Info (category = "",    
	       description = "Deprecated, do not use. Please use OnUnityEvent instead.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Collider.OnCollisionExit.html")]
	[System.Serializable]
	public class OnCollisionExit : StateCondition {
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject to use.")]
		public ObjectParameter gameObject;
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
			handler.onCollisionExit+=OnTrigger;
		}
		
		public override void OnExit ()
		{
			if (isTrigger) {
				handler.onCollisionExit -= OnTrigger;
			}
			isTrigger = false;
		}
		
		private void OnTrigger(GameObject other){
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