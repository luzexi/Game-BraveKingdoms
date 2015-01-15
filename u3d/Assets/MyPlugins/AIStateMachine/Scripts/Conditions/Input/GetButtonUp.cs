using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Input",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetButtonUp : StateCondition {
		[DefaultValueAttribute("Fire1")]
		[RequiredField(DefaultReference.Required)]
		public StringParameter buttonName;
		
		public override bool Validate ()
		{
			return Input.GetButtonUp(buttonName.Value);
		}
	}
}