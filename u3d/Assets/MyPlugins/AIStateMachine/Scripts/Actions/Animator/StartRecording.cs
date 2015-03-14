using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Sets the animator in recording mode, and allocates a circular buffer of size frameCount.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.StartRecording.html")]
	[System.Serializable]
	public class StartRecording : AnimatorAction {
		[Tooltip("The number of frames (updates) that will be recorded. If frameCount is 0, the recording will continue until the user calls StopRecording. The maximum value for frameCount is 10000.")]
		public IntParameter frameCount;
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.StartRecording (frameCount.Value);
		}
	}
}