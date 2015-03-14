using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",   
	       description = "Sets the value of a bool parameter.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetBool.html")]
	[System.Serializable]
	public class SetBool : AnimatorAction {
		[Tooltip("The animator bool parameter name to set.")]
		public StringParameter parameter;
		[Tooltip("The value to set.")]
		public BoolParameter value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.SetBool (parameter.Value, value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			animator.SetBool (parameter.Value, value.Value);
		}
	}
}