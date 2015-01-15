using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",   
	       description = "Gets the value of a bool parameter.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.GetBool.html")]
	[System.Serializable]
	public class GetBool : AnimatorAction {
		[Tooltip("The animator bool parameter name to set.")]
		public StringParameter parameter;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public BoolParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			store.Value = animator.GetBool (parameter.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = animator.GetBool (parameter.Value);
		}
	}
}