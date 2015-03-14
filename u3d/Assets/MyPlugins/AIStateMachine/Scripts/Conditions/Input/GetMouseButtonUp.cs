using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Input",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetMouseButtonUp : StateCondition {
		[Tooltip("Button values are 0 for left button, 1 for right button, 2 for the middle button.")]
		public IntParameter button;

		public override bool Validate ()
		{

			return Input.GetMouseButtonUp(button.Value);
		}
	}
}