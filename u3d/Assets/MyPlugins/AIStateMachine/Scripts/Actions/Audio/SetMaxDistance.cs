using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "(Logarithmic rolloff) MaxDistance is the distance a sound stops attenuating at. (Linear rolloff) MaxDistance is the distance where the sound is completely inaudible.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-maxDistance.html")]
	[System.Serializable]
	public class SetMaxDistance : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FloatParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.maxDistance = value.Value;
			Finish ();
		}
	}
}