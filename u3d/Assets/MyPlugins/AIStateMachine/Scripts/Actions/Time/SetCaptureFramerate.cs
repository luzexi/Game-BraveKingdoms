using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Time",    
	       description = "Slows game playback time to allow screenshots to be saved between frames.",
	       url = "http://docs.unity3d.com/ScriptReference/Time-captureFramerate.html")]
	[System.Serializable]
	public class SetCaptureFramerate : StateAction {
		[Tooltip("Value to set.")]
		public IntParameter framerate;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Time.captureFramerate = framerate.Value;

		}	
	}
}