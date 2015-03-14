using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent",    
	       description = "Stop movement of this agent along its current path.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent.Stop.html")]
	[System.Serializable]
	public class Stop : NavMeshAgentAction {
		[Tooltip("If true, the GameObject is stopped immediately and not affected by the avoidance system. If false, the NavMeshAgent controls the deceleration.")]
		public BoolParameter stopUpdates;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			agent.Stop (stopUpdates.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			agent.Stop (stopUpdates.Value);
		}
	}
}