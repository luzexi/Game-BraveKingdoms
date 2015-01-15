using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Parameter",    
	       description = "Determines whether the end of this string instance matches the specified string.",
	       url = "http://msdn.microsoft.com/en-us/library/2333wewz(v=vs.110).aspx")]
	[System.Serializable]
	public class IsStringEndWith : StateCondition {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Target string parameter to test.")]
		public StringParameter target;
		[Tooltip("End string sequence to test with.")]
		public StringParameter endsWith;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		public override bool Validate ()
		{
			return target.Value.StartsWith (endsWith.Value)== equals.Value;
		}
	}
}