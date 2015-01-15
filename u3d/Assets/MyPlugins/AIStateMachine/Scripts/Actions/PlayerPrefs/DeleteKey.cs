using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "PlayerPrefs",   
	       description = "Removes key and its corresponding value from the preferences.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.DeleteKey.html")]
	[System.Serializable]
	public class DeleteKey : StateAction {
		[Tooltip("The key to delete.")]
		public StringParameter key;

		public override void OnEnter ()
		{	
			PlayerPrefs.DeleteKey (key.Value);
		}
		
	}
}