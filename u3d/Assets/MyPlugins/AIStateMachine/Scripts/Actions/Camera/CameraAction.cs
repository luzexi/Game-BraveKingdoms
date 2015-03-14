using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public abstract class CameraAction : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("The GameObject to use.")]
		public ObjectParameter gameObject;
		
		protected Camera camera;
		
		public override void OnEnter (){
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			
			camera = ((GameObject)gameObject.Value).GetComponent<Camera> ();
			if (camera == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the Camera component on the GameObject. Action disabled! If you added the component in the same state, create a new state to run this action.");
			}
		}
	}
}