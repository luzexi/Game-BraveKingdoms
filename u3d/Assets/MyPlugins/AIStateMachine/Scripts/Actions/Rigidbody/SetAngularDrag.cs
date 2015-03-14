using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Angular drag can be used to slow down the rotation of an object. The higher the drag the more the rotation slows down.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody-angularDrag.html")]
	[System.Serializable]
	public class SetAngularDrag : RigidbodyAction {
		[Tooltip("Angular drag to set.")]
		public FloatParameter angularDrag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.angularDrag = angularDrag.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.angularDrag = angularDrag.Value;
		}
		
	}
}