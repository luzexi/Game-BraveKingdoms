using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine.Action{
	[Info (category = "NavMeshAgent",   
	       description = "Patrol",
	       url = "")]
	[System.Serializable]
	public class Patrol : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject that has a NavMeshAgent component.")]
		public ObjectParameter gameObject;
		[Tooltip("Speed of the agent")]
		[DefaultValueAttribute(3.5f)]
		public FloatParameter speed;
		[Tooltip("Angular speed of the agent")]
		[DefaultValueAttribute(120.0f)]
		public FloatParameter angularSpeed;
		[Tooltip("The agent has arrived when the remaining distance is less then this value")]
		[DefaultValueAttribute(1.5f)]
		public FloatParameter threshold;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("Root GameObject, that has child transforms.")]
		public ObjectParameter waypointRoot;
		
		private NavMeshAgent agent;
		private List<Vector3> waypoints;
		private Transform root;
		private int waypointIndex=0;
		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			if (waypointRoot.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			waypoints = new List<Vector3> ();
			root = ((GameObject)waypointRoot.Value).transform;
			foreach(Transform transform in root){
				waypoints.Add(transform.position);
			}

			agent = ((GameObject)gameObject.Value).GetComponent<NavMeshAgent> ();
			if (agent == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the NavMeshAgent component on the GameObject. Action disabled! If you added the component in the same state, create a new state to run this action.");
				return;
			}
			float distance = Mathf.Infinity;
			float localDistance;
			for (int i = 0; i < waypoints.Count; ++i) {
				if ((localDistance = Vector3.Magnitude(agent.transform.position - waypoints[i])) < distance) {
					distance = localDistance;
					waypointIndex = i;
				}
			}
			agent.speed = speed.Value;
			agent.angularSpeed = angularSpeed.Value;
			agent.enabled = true;
			DoPatrol ();
		}
		
		public override void OnUpdate ()
		{
			DoPatrol ();
		}
		
		private void DoPatrol(){
			if (!agent.pathPending) {
				if (agent.remainingDistance < threshold.Value) {
					waypointIndex = (waypointIndex + 1) % waypoints.Count;
					agent.destination = waypoints[waypointIndex];
				}
			}
		}
		
	}
}