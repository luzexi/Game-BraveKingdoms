using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent",   
	       description = "Sets or updates the destination thus triggering the calculation for a new path.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent.SetDestination.html")]
	[System.Serializable]
	public class SetDestination : NavMeshAgentAction {
		[Tooltip("The destination to set.")]
		public Vector3Parameter destination;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.None,false)]
		[Tooltip("Optional sets to targets position.")]
		public ObjectParameter target;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			if (target != null && !target.isNone && target.Value != null) {
				agent.SetDestination (((GameObject)target.Value).transform.position);
			} else {
				agent.SetDestination (destination.Value);
			}
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			if (target != null && !target.isNone && target.Value != null) {
				agent.SetDestination (((GameObject)target.Value).transform.position);
			} else {
				agent.SetDestination (destination.Value);
			}
		}
	}
}