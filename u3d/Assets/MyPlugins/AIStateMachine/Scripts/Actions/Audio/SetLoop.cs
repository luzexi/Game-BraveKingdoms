using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "If you disable looping on a playing AudioSource the sound will stop after the end of the current loop.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-loop.html")]
	[System.Serializable]
	public class SetLoop : AudioSourceAction {
		[Tooltip("Value to set.")]
		public BoolParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.loop = value.Value;
			Finish ();
		}
	}
}