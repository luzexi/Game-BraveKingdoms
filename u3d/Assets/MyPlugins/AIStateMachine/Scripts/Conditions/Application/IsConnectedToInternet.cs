using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Application",   
	       description = "Is there a connection to the internet?",
	       url = "")]
	[System.Serializable]
	public class IsConnectedToInternet : StateCondition {
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		public override bool Validate ()
		{
			return (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)==equals.Value;
		}

	}
}