using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Adds a torque to the rigidbody.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.AddTorque.html")]
	[System.Serializable]
	public class AddTorque : RigidbodyAction {
		[Tooltip("The torque to add.")]
		public Vector3Parameter torque;
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
			rigidbody.AddTorque (torque.Value, mode);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{	
			rigidbody.AddTorque (torque.Value, mode);
		}
		
	}
}