using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public class SetAvatar : AnimatorAction {
		[ObjectType(typeof(Avatar))]
		[RequiredField(DefaultReference.Required,false)]
		[Tooltip("Avatar to use.")]
		public ObjectParameter avatar;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.avatar = (Avatar)avatar.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
//			animator.avatar = (Avatar)avatar.Value;
		}
	}
}