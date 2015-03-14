using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "The volume of the audio source (0.0 to 1.0).",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-volume.html")]
	[System.Serializable]
	public class SetVolume : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FloatParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.volume= value.Value;
			Finish ();
		}
	}
}