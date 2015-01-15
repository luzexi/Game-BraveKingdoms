using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Within the Min distance the AudioSource will cease to grow louder in volume. Outside the min distance the volume starts to attenuate.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-minDistance.html")]
	[System.Serializable]
	public class SetMinDistance : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FloatParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.minDistance = value.Value;
			Finish ();
		}
	}
}