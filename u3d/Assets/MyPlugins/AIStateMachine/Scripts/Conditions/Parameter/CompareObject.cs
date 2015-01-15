using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",   
	       description = "Compares two UnityEngine.Object values.",
	       url = "")]
	[System.Serializable]
	public class CompareObject : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Parameter to test.")]
		public ObjectParameter parameter;
		[Tooltip("Value to test with.")]
		public ObjectParameter value;
		[Tooltip("Does the result equals this value.")]
		public BoolParameter equals;

		public override bool Validate ()
		{
			if (parameter.Value != null && value.Value != null) {
				return ((parameter.Value.GetInstanceID()== value.GetInstanceID())==equals.Value);			
			}
			return false;
		}
	}
}