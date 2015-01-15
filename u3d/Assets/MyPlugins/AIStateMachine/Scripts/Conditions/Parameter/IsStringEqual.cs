using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",    
	       description = "Is the first parameter equal to the second.",
	       url = "")]
	[System.Serializable]
	public class IsStringEqual : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("First parameter.")]
		public StringParameter first;
		[Tooltip("Second parameter.")]
		public StringParameter second;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;

		public override bool Validate ()
		{
			return (first.Value == second.Value)== equals.Value;
		}
	}
}