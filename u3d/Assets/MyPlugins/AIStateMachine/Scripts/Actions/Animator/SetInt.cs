using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Sets the value of an integer parameter.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetInteger.html")]
	[System.Serializable]
	public class SetInt : AnimatorAction {
		[Tooltip("The animator int parameter name to set.")]
		public StringParameter parameter;
		[Tooltip("The value to set.")]
		public IntParameter value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.SetInteger (parameter.Value, value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			animator.SetInteger (parameter.Value, value.Value);
		}
	}
}