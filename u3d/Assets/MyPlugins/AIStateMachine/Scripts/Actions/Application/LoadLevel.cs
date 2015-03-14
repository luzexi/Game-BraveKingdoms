using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Application",   
	       description = "Loads the level by its name.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Application.LoadLevel.html")]
	[System.Serializable]
	public class LoadLevel : StateAction {
		[Tooltip("The name of the level to load.")]
		public StringParameter level;

		public override void OnEnter ()
		{
			if (string.IsNullOrEmpty (level.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the level name is empty. Action disabled!");
				return;
			}
			Application.LoadLevel (level.Value);
			Finish ();
		}
	}
}