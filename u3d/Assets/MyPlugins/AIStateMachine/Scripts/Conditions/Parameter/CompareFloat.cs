using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",   
	       description = "Compares two float values.",
	       url = "")]
	[System.Serializable]
	public class CompareFloat : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Parameter to test.")]
		public FloatParameter parameter;
		[Tooltip("Float comparer.")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FloatParameter value;
		
		public override bool Validate ()
		{
			switch (comparer) {
			case FloatComparer.Less:
				return parameter.Value < value.Value;
			case FloatComparer.Greater:
				return parameter.Value > value.Value;
			case FloatComparer.Equal:
				return Mathf.Approximately(parameter.Value,value.Value);
			case FloatComparer.GreaterOrEqual:
				return parameter.Value >= value.Value;
			case FloatComparer.LessOrEqual:
				return parameter.Value <= value.Value;
			}
			return false;
		}
	}
}