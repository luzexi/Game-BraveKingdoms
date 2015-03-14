using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public class SetBypass : AudioSourceAction {
		[Tooltip("Bypass effects (Applied from filter components or global listener filters).")]
		public BoolParameter bypassEffects;
		public BoolParameter bypassListenerEffects;
		public BoolParameter bypassReverbZones;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.bypassEffects = bypassEffects.Value;
			audio.bypassListenerEffects = bypassListenerEffects.Value;
			audio.bypassReverbZones = bypassReverbZones.Value;
			Finish ();
		}
	}
}