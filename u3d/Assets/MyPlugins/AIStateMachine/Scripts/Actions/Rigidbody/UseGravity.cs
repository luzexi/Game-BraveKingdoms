using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Controls whether gravity affects this rigidbody.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody-useGravity.html")]
	[System.Serializable]
	public class UseGravity : RigidbodyAction {
		[Tooltip("Value to set.")]
		public BoolParameter useGravity;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.useGravity= useGravity.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.useGravity = useGravity.Value;
		}
		
	}
}