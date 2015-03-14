using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "PlayerPrefs",   
	       description = "Stores the value corresponding to key in the preference file if it exists.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.GetFloat.html")]
	[System.Serializable]
	public class GetFloat : StateAction {
		[Tooltip("The key to get.")]
		public StringParameter key;
		[Tooltip("The default value to set, if the key does not exist.")]
		public FloatParameter defaultValue;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = PlayerPrefs.GetFloat (key.Value, defaultValue.Value);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = PlayerPrefs.GetFloat (key.Value, defaultValue.Value);
		}
		
	}
}