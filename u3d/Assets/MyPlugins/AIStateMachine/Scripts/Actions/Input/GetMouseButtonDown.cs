using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Input",    
	       description = "Returns true during the frame the user pressed the given mouse button.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Input.GetMouseButtonDown.html")]
	[System.Serializable]
	public class GetMouseButtonDown : StateAction {
		[Tooltip("Button values are 0 for left button, 1 for right button, 2 for the middle button.")]
		public IntParameter button;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public BoolParameter store;
		
		public override void OnUpdate ()
		{
			store.Value = Input.GetMouseButtonDown (button.Value);	
		}
	}
}