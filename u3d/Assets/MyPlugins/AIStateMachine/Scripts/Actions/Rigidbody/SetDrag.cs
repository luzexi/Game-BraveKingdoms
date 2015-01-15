using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Drag can be used to slow down an object. The higher the drag the more the object slows down.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody-drag.html")]
	[System.Serializable]
	public class SetDrag : RigidbodyAction {
		[Tooltip("Drag to set.")]
		public FloatParameter drag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.drag = drag.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.drag = drag.Value;
		}
		
	}
}