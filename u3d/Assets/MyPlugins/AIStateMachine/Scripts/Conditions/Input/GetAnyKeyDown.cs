using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Input",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetAnyKeyDown : StateCondition {

		public override bool Validate ()
		{
			return Input.anyKeyDown;
		}
	}
}