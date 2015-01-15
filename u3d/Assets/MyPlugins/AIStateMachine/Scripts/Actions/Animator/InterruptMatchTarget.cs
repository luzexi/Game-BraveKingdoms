using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Interrupts the automatic target matching.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.InterruptMatchTarget.html")]
	[System.Serializable]
	public class InterruptMatchTarget : AnimatorAction {
		[Tooltip("Will make the gameobject match the target completely at the next frame.")]
		public BoolParameter completeMatch;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.InterruptMatchTarget (completeMatch.Value);
		}

	}
}