using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent", 
	       description = "Should the agent move via OffMeshLinks automatically?",
	       url = "http://docs.unity3d.com/ScriptReference/NavMeshAgent-autoTraverseOffMeshLink.html")]
	[System.Serializable]
	public class SetAutoTraverseOffMeshLink : NavMeshAgentAction {
		[Tooltip("The value to set.")]
		public BoolParameter value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			agent.autoTraverseOffMeshLink = value.Value;
		}
	}
}