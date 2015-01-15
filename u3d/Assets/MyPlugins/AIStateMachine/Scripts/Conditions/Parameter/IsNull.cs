using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",    
	       description = "Is the parameter null?",
	       url = "")]
	[System.Serializable]
	public class IsNull : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Parameter to test.")]
		public ObjectParameter target;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;

		public override bool Validate ()
		{
		//	Debug.Log (target.Value==null);
			return ((target.Value == null) == equals.Value);
		}
	}
}