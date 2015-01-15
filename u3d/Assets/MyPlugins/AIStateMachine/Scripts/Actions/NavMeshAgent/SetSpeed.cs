using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent", 
	       description = "Maximum movement speed when following a path.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-speed.html")]
	[System.Serializable]
	public class SetSpeed : NavMeshAgentAction {
		[Tooltip("The speed to set.")]
		public FloatParameter speed;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			agent.speed = speed.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			agent.speed = speed.Value;
		}
	}
}