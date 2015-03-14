using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Pauses playing the clip.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.Pause.html")]
	[System.Serializable]
	public class Pause : AudioSourceAction {

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.Pause ();
		}
	}
}