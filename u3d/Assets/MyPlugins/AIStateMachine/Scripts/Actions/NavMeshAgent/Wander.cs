using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "NavMeshAgent",   
	       description = "Wander",
	       url = "")]
	[System.Serializable]
	public class Wander : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject that has a NavMeshAgent component.")]
		public ObjectParameter gameObject;
		[RequiredField(DefaultReference.None)]
		[Tooltip("Start position to wander around.")]
		public Vector3Parameter startPosition;
		[Tooltip("Speed of the agent")]
		[DefaultValueAttribute(3.5f)]
		public FloatParameter speed;
		[Tooltip("Angular speed of the agent")]
		[DefaultValueAttribute(120.0f)]
		public FloatParameter angularSpeed;
		[Tooltip("The agent has arrived when the remaining distance is less then this value")]
		[DefaultValueAttribute(0.5f)]
		public FloatParameter threshold;
		[Tooltip("How far away to wander from the current position")]
		[DefaultValueAttribute(20f)]
		public FloatParameter wanderDistance;
		[Tooltip("Turn rate.")]
		[DefaultValueAttribute(2.0f)]
		public FloatParameter turnRate;

		private NavMeshAgent agent;
		
		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			agent = ((GameObject)gameObject.Value).GetComponent<NavMeshAgent> ();
			if (agent == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the NavMeshAgent component on the GameObject. Action disabled! If you added the component in the same state, create a new state to run this action.");
				return;
			}

			agent.speed = speed.Value;
			agent.angularSpeed = angularSpeed.Value;
			agent.enabled = true;
			agent.destination = startPosition.isNone?GetNextPosition():GetNextPositionWithin(startPosition.Value);
		}

		public override void OnUpdate ()
		{
			if (agent.remainingDistance < threshold.Value) {
				agent.destination = startPosition.isNone?GetNextPosition():GetNextPositionWithin(startPosition.Value);
			}
		}

		private Vector3 GetNextPosition(){
			Vector3 direction = agent.transform.forward + Random.insideUnitSphere * turnRate.Value;
			return agent.transform.position + direction.normalized * wanderDistance.Value;
		}

		private Vector3 GetNextPositionWithin(Vector3 _startPos){
			Vector3	pos = _startPos + (Random.insideUnitSphere * Random.Range(1.0f, this.agent.radius));
			
			var dir = (pos - this.agent.transform.position);
			var dist = dir.magnitude;
			if (dist < this.wanderDistance)
			{
				pos = this.agent.transform.position + ((dir / dist) * this.wanderDistance);
			}	
			return pos;
		}


	}
}