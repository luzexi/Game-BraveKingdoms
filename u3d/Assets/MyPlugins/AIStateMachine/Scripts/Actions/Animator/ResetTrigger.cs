using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",   
	       description = "A trigger parameter is like a bool parameter, but the parameter is reset to false once the parameter has been consumed by a transition condition.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.ResetTrigger.html")]
	[System.Serializable]
	public class ResetTrigger : AnimatorAction {
		[Tooltip("The name of the parameter.")]
		public StringParameter parameter;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.ResetTrigger (parameter.Value);
		}
	}
}