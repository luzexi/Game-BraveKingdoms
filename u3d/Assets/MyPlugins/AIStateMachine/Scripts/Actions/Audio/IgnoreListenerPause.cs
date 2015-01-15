using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Audio",   
	       description = "Allows AudioSource to play even though AudioListener.pause is set to true. This is useful for the menu element sounds or background music in pause menus.",
	       url = "http://docs.unity3d.com/ScriptReference/AudioSource-ignoreListenerPause.html")]
	[System.Serializable]
	public class IgnoreListenerPause : AudioSourceAction {
		[Tooltip("Check to ignore.")]
		public BoolParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			audio.ignoreListenerPause = value.Value;
			Finish ();
		}
	}
}