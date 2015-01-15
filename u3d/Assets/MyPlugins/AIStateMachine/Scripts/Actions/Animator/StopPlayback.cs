using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Stops the animator playback mode. When playback stops, the avatar resumes getting control from game logic.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.StopPlayback.html")]
	[System.Serializable]
	public class StopPlayback : AnimatorAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.StopPlayback ();
		}
	}
}