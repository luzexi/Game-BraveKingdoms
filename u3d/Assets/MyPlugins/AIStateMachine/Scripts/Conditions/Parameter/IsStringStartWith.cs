using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",    
	       description = "Is the first parameter equal to the second.",
	       url = "")]
	[System.Serializable]
	public class IsStringStartWith : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Target string parameter to test.")]
		public StringParameter target;
		[Tooltip("Start string sequence to test with.")]
		public StringParameter startWith;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;

		public override bool Validate ()
		{
			return target.Value.StartsWith (startWith.Value)== equals.Value;
		}
	}
}