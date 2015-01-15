using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Application",   
	       description = "Is the current platform Editor?",
	       url = "")]
	[System.Serializable]
	public class IsEditor : StateCondition {
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		public override bool Validate ()
		{
			return Application.isEditor==equals.Value;
		}
		
	}
}