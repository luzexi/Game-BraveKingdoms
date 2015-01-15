using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",   
	       description = "Sets a trigger parameter to active or inactive.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetTrigger.html")]
	[System.Serializable]
	public class SetTrigger : AnimatorAction {
		[Tooltip("The animator trigger parameter name.")]
		public StringParameter parameter;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.SetTrigger (parameter.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			animator.SetTrigger (parameter.Value);
		}
	}
}