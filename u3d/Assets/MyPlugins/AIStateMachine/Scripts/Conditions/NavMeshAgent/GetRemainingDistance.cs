using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "NavMeshAgent", 
	       description = "The distance between the agent's position and the destination on the current path.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-remainingDistance.html")]
	[System.Serializable]
	public class GetRemainingDistance : StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("NavMeshAgent to use.")]
		public ObjectParameter gameObject;
		[Tooltip("Is the distance greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FloatParameter value;

		private NavMeshAgent agent;

		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+gameObject.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}
			agent = ((GameObject)gameObject.Value).GetComponent<NavMeshAgent> ();
			if (agent == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the NavMeshAgent component on the GameObject. Condition disabled!");
			}
		}
		
		public override bool Validate ()
		{	
			switch (comparer) {
			case FloatComparer.Less:
				return agent.remainingDistance < value.Value;
			case FloatComparer.Greater:
				return agent.remainingDistance > value.Value;
			}
			return false;
		}
	}
}