using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class Play : AnimatorAction {
		[Tooltip("The state hash")]
		public IntParameter hash;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.Play (hash);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			animator.Play (hash);
		}
	}
}