using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Input",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetKeyUp : StateCondition {
		public KeyCode keyCode;
		
		public override bool Validate ()
		{
			return Input.GetKeyUp(keyCode);
		}
	}
}