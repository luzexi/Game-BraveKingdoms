using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Input",    
	       description = "Returns true the first frame the user releases the virtual button identified by buttonName.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Input.GetButtonUp.html")]
	[System.Serializable]
	public class GetButtonUp : StateAction {
		[Tooltip("Virtual button name.")]
		public StringParameter buttonName;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public BoolParameter store;

		public override void OnEnter ()
		{
			if (string.IsNullOrEmpty (buttonName.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the buttonName parameter is empty. Action disabled!");
				return;
			}
			store.Value = Input.GetButtonUp (buttonName.Value);	
		}

		public override void OnUpdate ()
		{
			store.Value = Input.GetButtonUp (buttonName.Value);	
		}
	}
}