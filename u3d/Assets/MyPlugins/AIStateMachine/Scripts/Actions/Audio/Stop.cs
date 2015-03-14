using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Stops playing the clip.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource.Stop.html")]
	[System.Serializable]
	public class Stop : AudioSourceAction {

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			audio.Stop ();
			Finish ();
		}
	}
}