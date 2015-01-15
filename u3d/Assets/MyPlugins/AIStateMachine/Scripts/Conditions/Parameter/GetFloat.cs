using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",   
	       description = "Deprecated, do not use. Please use CompareFloat instead.",
	       url = "")]
	[System.Serializable]
	public class GetFloat : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Parameter to test.")]
		public FloatParameter parameter;
		[Tooltip("Is the parameter greater or less?")]
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
			case FloatComparer.NotEqual:
				return !Mathf.Approximately(parameter.Value,value.Value);
			}
			return false;
		}
	}
}