using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "This makes the audio source not take into account the volume of the audio listener.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-ignoreListenerVolume.html")]
	[System.Serializable]
	public class IgnoreListenerVolume : AudioSourceAction {
		[Tooltip("Check to ignore.")]
		public BoolParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			audio.ignoreListenerVolume = value.Value;
			Finish ();
		}
	}
}