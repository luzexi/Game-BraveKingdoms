using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "PlayerPrefs",   
	       description = "Stores the value corresponding to key in the preference file if it exists.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.GetInt.html")]
	[System.Serializable]
	public class GetInt : StateAction {
		[Tooltip("The key to get.")]
		public StringParameter key;
		[Tooltip("The default value to set, if the key does not exist.")]
		public IntParameter defaultValue;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result")]
		public IntParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = PlayerPrefs.GetInt (key.Value, defaultValue.Value);
			
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = PlayerPrefs.GetInt (key.Value, defaultValue.Value);
		}
		
	}
}