using UnityEngine;
using System.Collections;

namespace  StateMachine.Action{
	[Info (category = "Application",    
	       description = "Should the player be running when the application is in the background?",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Application-runInBackground.html")]
	[System.Serializable]
	public class RunInBackground : StateAction {
		[Tooltip("State value to set, true or false.")]
		public BoolParameter state;
		
		public override void OnEnter ()
		{
			Application.runInBackground = state.Value;
			Finish ();
		}
	}
}