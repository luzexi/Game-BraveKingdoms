using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Applies a force to the rigidbody that simulates explosion effects. The explosion force will fall off linearly with distance to the rigidbody.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.AddExplosionForce.html")]
	[System.Serializable]
	public class AddExplosionForce : RigidbodyAction {
		[Tooltip("The force to add.")]
		public FloatParameter explosionForce;
		[Tooltip("Position to add the force at.")]
		public Vector3Parameter position;
		[Tooltip("Radius to add the force inside.")]
		public FloatParameter radius;
		[Tooltip("Upwards modifier.")]
		public FloatParameter upwardsModifier;
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
			rigidbody.AddExplosionForce (explosionForce.Value, position.Value, radius.Value, upwardsModifier.Value, mode);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnFixedUpdate ()
		{
			rigidbody.AddExplosionForce (explosionForce.Value, position.Value, radius.Value, upwardsModifier.Value, mode);
		}
		
	}
}