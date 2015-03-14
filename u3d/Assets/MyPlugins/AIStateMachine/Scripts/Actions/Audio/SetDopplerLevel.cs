using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Sets the Doppler scale for this AudioSource.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-dopplerLevel.html")]
	[System.Serializable]
	public class SetDopplerLevel : AudioSourceAction {
		[Tooltip("Scale to set.")]
		public FloatParameter dopplerLevel;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.dopplerLevel = dopplerLevel.Value;
			Finish ();
		}
	}
}