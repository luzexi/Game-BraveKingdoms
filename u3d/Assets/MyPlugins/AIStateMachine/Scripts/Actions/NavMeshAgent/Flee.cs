using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "NavMeshAgent",   
	       description = "Flee from target.",
	       url = "")]
	[System.Serializable]
	public class Flee : StateAction {
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
		[Tooltip("The agent has fleed when the distance is greater then this value")]
		[DefaultValueAttribute(10.0f)]
		public FloatParameter fleedDistance;
		
		
		private NavMeshAgent agent;
		private Transform mTarget;
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
			agent.enabled = true;
			agent.destination = GetFleePosition ();
		}
		
		public override void OnUpdate ()
		{
			if (Vector3.Distance (agent.transform.position, mTarget.position) < fleedDistance.Value) {
				agent.destination = GetFleePosition (); 
			}
		}
		
		private Vector3 GetFleePosition(){
			return agent.transform.position + (agent.transform.position - mTarget.position).normalized * 5;
		}
		
	}
}