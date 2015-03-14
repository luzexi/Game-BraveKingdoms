using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",    
	       description = "Returns a value indicating whether a specified substring occurs within this string.",
	       url = "")]
	[System.Serializable]
	public class ContainsString : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("First parameter.")]
		public StringParameter first;
		[Tooltip("Second parameter.")]
		public StringParameter second;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		public override bool Validate ()
		{
			return (first.Value.Contains(second.Value)== equals.Value);
		}
	}
}