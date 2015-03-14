using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetPlayingState : AnimatorAction {
		[Tooltip("Animator layer.")]
		public IntParameter layer;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the name hash.")]
		public IntParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (layer.Value);
			store.Value=info.nameHash;
			
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (layer.Value);
			store.Value=info.nameHash;
		}
	}
}