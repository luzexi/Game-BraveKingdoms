using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent",  
	       description = "Projects the desired velocity of the NavMeshAgent with transforms forward vector.",
	       url = "")]
	[System.Serializable]
	public class GetProjectedVelocity : NavMeshAgentAction {
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The projected velocity.")]
		public Vector3Parameter velocity;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The magnitude of the velocity.")]
		public FloatParameter magnitude;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
	
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Vector3 vel = Vector3.Project (agent.desiredVelocity, agent.transform.forward);
			velocity.Value = vel;
			magnitude.Value = vel.magnitude;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			Vector3 vel = Vector3.Project (agent.desiredVelocity, agent.transform.forward);
			velocity.Value = vel;
			magnitude.Value = vel.magnitude;
		}
	}
}