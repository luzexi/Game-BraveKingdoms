using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent", 
	       description = "Resumes the movement along the current path after a pause.",
	       url = "http://docs.unity3d.com/ScriptReference/NavMeshAgent.Resume.html")]
	[System.Serializable]
	public class Resume : NavMeshAgentAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			agent.Resume ();
		}
	}
}