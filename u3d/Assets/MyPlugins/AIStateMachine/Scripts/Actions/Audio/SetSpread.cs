using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Sets the spread angle a 3d stereo or multichannel sound in speaker space.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-spread.html")]
	[System.Serializable]
	public class SetSpread : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FloatParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.spread= value.Value;
			Finish ();
		}
	}
}