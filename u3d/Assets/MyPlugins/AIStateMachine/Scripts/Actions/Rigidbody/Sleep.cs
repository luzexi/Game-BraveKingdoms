using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Forces a rigidbody to sleep at least one frame.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody.Sleep.html")]
	[System.Serializable]
	public class Sleep : RigidbodyAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.Sleep ();
		}	
	}
}