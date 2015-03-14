using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Debug",   
	       description = "Prints a message to the console.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Debug.Log.html")]
	[System.Serializable]
	public class Log : StateAction {
		[Tooltip("Message to print.")]
		public StringParameter message;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			Debug.Log (message.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			Debug.Log (message.Value);
		}
	}
}
