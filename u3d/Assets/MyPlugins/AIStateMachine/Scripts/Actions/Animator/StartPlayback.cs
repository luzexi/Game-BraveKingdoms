using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Sets the animator in playback mode.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.StartPlayback.html")]
	[System.Serializable]
	public class StartPlayback : AnimatorAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.StartPlayback ();
		}
	}
}