using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Mute/unmute the Audio Clip played by an Audio Source component on a Game Object.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-mute.html")]
	[System.Serializable]
	public class Mute : AudioSourceAction {
		[Tooltip("Check to mute, uncheck to unmute.")]
		public BoolParameter mute;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.mute = mute.Value;
			Finish ();
		}
	}
}