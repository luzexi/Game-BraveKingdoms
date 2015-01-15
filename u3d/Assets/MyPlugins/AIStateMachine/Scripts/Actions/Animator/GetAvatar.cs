using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetAvatar : AnimatorAction {

		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public ObjectParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			store.Value = animator.avatar;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = animator.avatar;
		}
	}
}