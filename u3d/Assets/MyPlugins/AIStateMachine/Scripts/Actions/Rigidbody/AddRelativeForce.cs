using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Adds a force to the rigidbody relative to its coordinate system.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.AddRelativeForce.html")]
	[System.Serializable]
	public class AddRelativeForce : RigidbodyAction {
		[Tooltip("The force to add.")]
		public Vector3Parameter force;
		[Tooltip("Option for how to apply a force using Rigidbody.AddForce.")]
		public ForceMode mode;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.AddRelativeForce (force.Value, mode);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.AddRelativeForce (force.Value, mode);
		}
		
	}
}