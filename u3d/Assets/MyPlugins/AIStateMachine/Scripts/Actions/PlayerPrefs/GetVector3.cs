using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "PlayerPrefs",   
	       description = "Stores the value corresponding to key in the preference file if it exists.",
	       url = "")]
	[System.Serializable]
	public class GetVector3 : StateAction {
		[Tooltip("The key to get.")]
		public StringParameter key;
		[Tooltip("The default value to set, if the key does not exist.")]
		public Vector3Parameter defaultValue;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			float x=PlayerPrefs.GetFloat (key.Value+"_x", defaultValue.Value.x);
			float y=PlayerPrefs.GetFloat (key.Value+"_y", defaultValue.Value.y);
			float z=PlayerPrefs.GetFloat (key.Value+"_z", defaultValue.Value.z);
			store.Value = new Vector3 (x, y, z);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			float x=PlayerPrefs.GetFloat (key.Value+"_x", defaultValue.Value.x);
			float y=PlayerPrefs.GetFloat (key.Value+"_y", defaultValue.Value.y);
			float z=PlayerPrefs.GetFloat (key.Value+"_z", defaultValue.Value.z);
			store.Value = new Vector3 (x, y, z);
		}
		
	}
}