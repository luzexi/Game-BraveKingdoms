using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Sets how the AudioSource attenuates over distance.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-rolloffMode.html")]
	[System.Serializable]
	public class SetRolloffMode : AudioSourceAction {
		[Tooltip("Mode to set.")]
		public AudioRolloffMode mode;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.rolloffMode = mode;
			Finish ();
		}
	}
}