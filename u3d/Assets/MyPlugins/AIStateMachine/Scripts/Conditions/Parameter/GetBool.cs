using UnityEngine;
using System.Collections;


namespace StateMachine.Condition{
	[Info (category = "Parameter",   
	       description = "Deprecated, do not use. Please use CompareBool instead.",
	       url = "")]
	[System.Serializable]
	public class GetBool : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Parameter to test.")]
		public BoolParameter parameter;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		public override bool Validate ()
		{
			return ((parameter.Value == true) == equals.Value);
		}
	}
}