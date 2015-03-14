using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Controls whether physics affects the rigidbody.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody-isKinematic.html")]
	[System.Serializable]
	public class SetKinematic : RigidbodyAction {
		[Tooltip("Value to set.")]
		public BoolParameter value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.isKinematic = value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.isKinematic = value.Value;
		}
		
	}
}