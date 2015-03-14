using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Plays a random clip with an optional certain delay.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.Play.html")]
	[System.Serializable]
	public class PlayRandom : AudioSourceAction {
		public List<AudioClip> clips;
		[Tooltip("Delay in seconds.")]
		public FloatParameter delay;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.clip = clips [Random.Range (0, clips.Count)];
			audio.PlayDelayed (delay.Value);
			Finish ();
		}
	}
}