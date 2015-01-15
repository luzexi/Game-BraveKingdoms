using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Debug",   
	       description = "Pauses the editor.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Debug.Break.html")]
	[System.Serializable]
	public class Break : StateAction {
		public override void OnEnter ()
		{
			Debug.Break ();
			Finish ();
		}
	}
}
