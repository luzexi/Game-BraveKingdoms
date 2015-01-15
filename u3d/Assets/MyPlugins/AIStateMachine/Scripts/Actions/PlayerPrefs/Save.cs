using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "PlayerPrefs",   
	       description = "Writes all modified preferences to disk.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.Save.html")]
	[System.Serializable]
	public class Save : StateAction {
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			PlayerPrefs.Save ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			PlayerPrefs.Save ();
		}
		
	}
}