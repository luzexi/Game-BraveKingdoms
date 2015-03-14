using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Debug",  
	       description = "Plays system beep sound.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/EditorApplication.Beep.html")]
	[System.Serializable]
	public class Beep : StateAction {

		public override void OnEnter ()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.Beep();
			#endif
			Finish ();
		}
	}
}
