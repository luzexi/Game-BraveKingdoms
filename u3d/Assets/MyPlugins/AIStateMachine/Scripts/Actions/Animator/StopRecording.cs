using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Stops animator record mode.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.StopRecording.html")]
	[System.Serializable]
	public class StopRecording : AnimatorAction {
		[RequiredField(DefaultReference.None)]
		[Tooltip("The recorder StartTime")]
		public FloatParameter recorderStartTime;
		[RequiredField(DefaultReference.None)]
		[Tooltip("The recorder StopTime")]
		public FloatParameter recorderStopTime;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.StopRecording ();
			recorderStartTime.Value = animator.recorderStartTime;
			recorderStopTime.Value = animator.recorderStopTime;
		}
	}
}