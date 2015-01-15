using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "PlayerPrefs",   
	       description = "Stores true if key exists in the preferences.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.HasKey.html")]
	[System.Serializable]
	public class HasKey : StateAction {
		[Tooltip("The key to get.")]
		public StringParameter key;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public BoolParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = PlayerPrefs.HasKey (key.Value);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = PlayerPrefs.HasKey (key.Value);
		}
		
	}
}