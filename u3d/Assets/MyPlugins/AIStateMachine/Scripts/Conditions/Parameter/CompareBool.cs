using UnityEngine;
using System.Collections;


namespace StateMachine.Condition{
	[Info (category = "Parameter",   
	       description = "Compares if a bool parameter equals true or false.",
	       url = "")]
	[System.Serializable]
	public class CompareBool : StateCondition {
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