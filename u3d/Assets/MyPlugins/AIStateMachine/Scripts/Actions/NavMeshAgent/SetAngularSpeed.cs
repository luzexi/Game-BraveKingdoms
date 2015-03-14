using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent",  
	       description = "Maximum turning speed in (deg/s) while following a path.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-angularSpeed.html")]
	[System.Serializable]
	public class SetAngularSpeed : NavMeshAgentAction {
		[Tooltip("The angular speed to set.")]
		public FloatParameter angularSpeed;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			agent.angularSpeed = angularSpeed.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			agent.angularSpeed = angularSpeed.Value;
		}
	}
}