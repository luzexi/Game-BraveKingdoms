using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",    
	       description = "Plays an AudioClip, and scales the AudioSource volume by volumeScale.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.PlayOneShot.html")]
	[System.Serializable]
	public class PlayOneShot : AudioSourceAction {
		[ObjectType(typeof(AudioClip))]
		[Tooltip("The clip being played.")]
		public ObjectParameter clip;
		[Tooltip("The scale of the volume (0-1).")]
		public FloatParameter volumeScale;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.PlayOneShot ((AudioClip)clip.Value, volumeScale.Value);
			Finish ();
		}
	}
}