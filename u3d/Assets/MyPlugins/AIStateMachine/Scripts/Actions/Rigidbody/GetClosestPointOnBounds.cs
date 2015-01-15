using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "The closest point to the bounding box of the attached colliders.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody.ClosestPointOnBounds.html")]
	[System.Serializable]
	public class GetClosestPointOnBounds : RigidbodyAction {
		public Vector3Parameter position;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			store.Value = rigidbody.ClosestPointOnBounds (position.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = rigidbody.ClosestPointOnBounds (position.Value);
		}
	}
}