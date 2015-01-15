using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Sets the mass of the rigidbody.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody-mass.html")]
	[System.Serializable]
	public class SetMass : RigidbodyAction {
		[Tooltip("Mass to set.")]
		public FloatParameter mass;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.mass = mass.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.mass = mass.Value;
		}
		
	}
}