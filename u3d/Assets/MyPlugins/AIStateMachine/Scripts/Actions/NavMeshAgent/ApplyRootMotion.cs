using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent",    
	       description = "Updates the velocity of the NavMeshAgent with root motion data.",
	       url = "")]
	[System.Serializable]
	public class ApplyRootMotion : NavMeshAgentAction {
		[Tooltip("Value to set.")]
		public BoolParameter value;

		private Animator animator;
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			animator = agent.GetComponent<Animator> ();
			if (animator == null) {
				enabled = false;
				Debug.LogWarning ("Missing Component! " + GetType ().ToString () + " requires the Animator component on the GameObject. Action disabled!");
				return;
			}
		}
		
		public override void OnAnimatorMove ()
		{
			agent.updateRotation = !value.Value;
			if (value.Value) {
				agent.transform.rotation=animator.rootRotation;
				if(agent != null){
					agent.velocity = animator.deltaPosition / Time.deltaTime;
				}
			}
		}
	}
}