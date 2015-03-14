using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Debug",  
	       description = "Clears errors from the developer console.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Debug.ClearDeveloperConsole.html")]
	[System.Serializable]
	public class ClearDeveloperConsole : StateAction {
		
		public override void OnEnter ()
		{
			Debug.ClearDeveloperConsole ();
			Finish ();
		}
	}
}
