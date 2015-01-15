using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Sets the pitch of the audio source.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-pitch.html")]
	[System.Serializable]
	public class SetPitch : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FloatParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.pitch = value.Value;
			Finish ();
		}
	}
}