using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",   
	       description = "Compares two int values.",
	       url = "")]
	[System.Serializable]
	public class CompareInt : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Parameter to test.")]
		public IntParameter parameter;
		
		[Tooltip("Is the parameter greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public IntParameter value;
		
		public override bool Validate ()
		{
			
			//Debug.Log (parameter.Name + " " + parameter.Value + ">" + value.Name + " " + value.Value);
			switch (comparer) {
			case FloatComparer.Less:
				return parameter.Value < value.Value;
			case FloatComparer.Greater:
				return parameter.Value > value.Value;
			case FloatComparer.Equal:
				return parameter.Value==value.Value;
			case FloatComparer.GreaterOrEqual:
				return parameter.Value >= value.Value;
			case FloatComparer.LessOrEqual:
				return parameter.Value <= value.Value;
			case FloatComparer.NotEqual:
				return parameter.Value != value.Value;
			}
			return false;
		}
	}
}