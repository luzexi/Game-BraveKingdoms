using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent", 
	       description = "",
	       url = "http://docs.unity3d.com/ScriptReference/NavMeshAgent.CompleteOffMeshLink.html")]
	[System.Serializable]
	public class CompleteOffMeshLink : NavMeshAgentAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			agent.CompleteOffMeshLink ();
		}
	}
}