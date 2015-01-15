using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent",  
	       description = "The distance between the agent's position and the destination on the current path.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-remainingDistance.html")]
	[System.Serializable]
	public class GetRemainingDistance : NavMeshAgentAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Result to store.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			store.Value = agent.remainingDistance;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = agent.remainingDistance;
		}
	}
}