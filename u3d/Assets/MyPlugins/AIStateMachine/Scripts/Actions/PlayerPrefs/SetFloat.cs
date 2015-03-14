using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Prefs{
	[Info (category = "PlayerPrefs",   
	       description = "Sets the value of the preference identified by key.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.SetFloat.html")]
	[System.Serializable]
	public class SetFloat : StateAction {
		[Tooltip("The key to set.")]
		public StringParameter key;
		[Tooltip("The value to set.")]
		public FloatParameter value;
	
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			PlayerPrefs.SetFloat (key.Value, value.Value);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			PlayerPrefs.SetFloat (key.Value, value.Value);
		}
		
	}
}