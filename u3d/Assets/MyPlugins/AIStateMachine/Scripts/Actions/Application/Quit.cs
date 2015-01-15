using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Application",  
	       description = "Quits the player application. Quit is ignored in the editor or the web player.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Application.Quit.html")]
	[System.Serializable]
	public class Quit : StateAction {

		public override void OnEnter ()
		{
			Application.Quit ();
			Finish ();
		}
	}
}