using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Prefs{
	[Info (category = "PlayerPrefs",   
	       description = "Stores the value corresponding to key in the preference file if it exists.",
	       url = "")]
	[System.Serializable]
	public class GetBool : StateAction {
		[Tooltip("The key to get.")]
		public StringParameter key;
		[Tooltip("The default value to set, if the key does not exist.")]
		public BoolParameter defaultValue;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result")]
		public BoolParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = (PlayerPrefs.GetInt (key.Value, defaultValue.Value?1:0)==0?false:true);
			
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = (PlayerPrefs.GetInt (key.Value, defaultValue.Value?1:0)==0?false:true);
		}
		
	}
}