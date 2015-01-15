using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "The velocity of the rigidbody at the point worldPoint in global space.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody.GetPointVelocity.html")]
	[System.Serializable]
	public class GetPointVelocity : RigidbodyAction {
		public Vector3Parameter worldPoint;
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
			store.Value = rigidbody.GetPointVelocity (worldPoint.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = rigidbody.GetPointVelocity (worldPoint.Value);
		}
	}
}