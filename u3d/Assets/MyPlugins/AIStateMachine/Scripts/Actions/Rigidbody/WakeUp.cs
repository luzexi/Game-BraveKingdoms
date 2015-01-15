using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "Forces a rigidbody to wake up.",
	       url = "http://docs.unity3d.com/ScriptReference/Rigidbody.WakeUp.html")]
	[System.Serializable]
	public class WakeUp : RigidbodyAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			rigidbody.WakeUp ();
		}	
	}
}