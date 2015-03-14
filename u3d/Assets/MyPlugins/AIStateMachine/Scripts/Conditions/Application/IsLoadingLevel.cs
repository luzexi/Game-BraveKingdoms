using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Application",   
	       description = "Is some level being loaded?",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Application-isLoadingLevel.html")]
	[System.Serializable]
	public class IsLoadingLevel : StateCondition {
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;

		public override bool Validate ()
		{
			return Application.isLoadingLevel== equals.Value;
		}
	}
}