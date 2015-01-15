using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class RigidbodyAction : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GamgeObject that has a Rigidbody component.")]
		public ObjectParameter gameObject;
	
		protected Rigidbody rigidbody;
		
		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			rigidbody = ((GameObject)gameObject.Value).GetComponent<Rigidbody> ();
			if (rigidbody == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the Rigidbody component on the GameObject. Action disabled! If you added the component in the same state, create a new state to run this action.");
			}
		}	
	}
}