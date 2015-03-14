using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "PlayerPrefs",   
	       description = "Removes all keys and values from the preferences. Use with caution.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.DeleteAll.html")]
	[System.Serializable]
	public class DeleteAll : StateAction {

		public override void OnEnter ()
		{	
			PlayerPrefs.DeleteAll ();
		}
		
	}
}