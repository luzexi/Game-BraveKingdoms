using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent",   
	       description = "The current velocity of the NavMeshAgent component.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-velocity.html")]
	[System.Serializable]
	public class GetVelocity : NavMeshAgentAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Result to store.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			store.Value = agent.velocity;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = agent.velocity;
		}
	}
}