using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Physics",  
	       description = "Makes the collision detection system ignore all collisions between collider1 and collider2.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Physics.IgnoreCollision.html")]
	[System.Serializable]
	public class IgnoreCollision : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("The GameObject to use.")]
		public ObjectParameter gameObject;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Required,false)]
		[Tooltip("Second GameObject to ignore collision with.")]
		public ObjectParameter target;
		[Tooltip("Ignore the collsion if true.")]
		public BoolParameter ignore;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private Collider collider1;
		private Collider collider2;

		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+gameObject.Name+" in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}

			if (target.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+target.Name+" in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			
			collider1 = ((GameObject)gameObject.Value).GetComponent<Collider> ();
			if (collider1 == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the Collider component on the GameObject. Action disabled! If you added the component in the same state, create a new state to run this action.");
			}
			collider2 = ((GameObject)target.Value).GetComponent<Collider> ();
			if (collider2 == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the Collider component on the GameObject. Action disabled! If you added the component in the same state, create a new state to run this action.");
			}
			Physics.IgnoreCollision (collider1, collider2, ignore.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			Physics.IgnoreCollision (collider1, collider2, ignore.Value);
		}
	}
}