using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Input",  
	       description = "Returns whether the given mouse button is held down.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Input.GetMouseButton.html")]
	[System.Serializable]
	public class GetMouseButton : StateAction {
		[Tooltip("Button values are 0 for left button, 1 for right button, 2 for the middle button.")]
		public IntParameter button;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public BoolParameter store;
		
		public override void OnUpdate ()
		{
			store.Value = Input.GetMouseButton (button.Value);	
		}
	}
}