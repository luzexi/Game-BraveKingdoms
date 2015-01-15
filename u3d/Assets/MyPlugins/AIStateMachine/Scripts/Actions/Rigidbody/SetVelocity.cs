using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Sets velocity vector of the rigidbody.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html")]
	[System.Serializable]
	public class SetVelocity : RigidbodyAction {
		[Tooltip("Velocity to set.")]
		public Vector3Parameter velocity;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.velocity = velocity.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnFixedUpdate ()
		{
			rigidbody.velocity = velocity.Value;
		}
		
	}
}