using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Input",    
	       description = "Returns true during the frame the user pressed the given mouse button.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Input.GetMouseButtonDown.html")]
	[System.Serializable]
	public class GetMouseButtonDown : StateCondition {
		[Tooltip("Button values are 0 for left button, 1 for right button, 2 for the middle button.")]
		public IntParameter button;
		
		public override bool Validate ()
		{
			return Input.GetMouseButtonDown(button.Value);
		}
	}
}