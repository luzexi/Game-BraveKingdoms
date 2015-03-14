using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "NavMeshAgent",   
	       description = "Seek a target.",
	       url = "")]
	[System.Serializable]
	public class Seek : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject that has a NavMeshAgent component.")]
		public ObjectParameter gameObject;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("Target to seek.")]
		public ObjectParameter target;
		[Tooltip("Speed of the agent")]
		[DefaultValueAttribute(3.5f)]
		public FloatParameter speed;
		[Tooltip("Angular speed of the agent")]
		[DefaultValueAttribute(120.0f)]
		public FloatParameter angularSpeed;
		[Tooltip("The agent has arrived when the distance to target is less then this value")]
		[DefaultValueAttribute(1.5f)]
		public FloatParameter stoppingDistance;

		
		private NavMeshAgent agent;
		private Transform mTarget;
		private Vector3 lastTargetPosition;

		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}

			if (target.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			mTarget = ((GameObject)target.Value).transform;

			agent = ((GameObject)gameObject.Value).GetComponent<NavMeshAgent> ();
			if (agent == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the NavMeshAgent component on the GameObject. Action disabled! If you added the component in the same state, create a new state to run this action.");
				return;
			}
			
			agent.speed = speed.Value;
			agent.angularSpeed = angularSpeed.Value;
			agent.stoppingDistance = stoppingDistance.Value;
			agent.enabled = true;
			agent.destination = GetTargetPosition ();
		}
		
		public override void OnUpdate ()
		{
			agent.destination = GetTargetPosition (); 
		}

		private Vector3 GetTargetPosition(){
			if (mTarget != null) {
				lastTargetPosition=mTarget.position;			
			}
			return lastTargetPosition;
		}
		
	}
}