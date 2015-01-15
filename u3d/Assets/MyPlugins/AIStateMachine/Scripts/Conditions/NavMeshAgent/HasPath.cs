using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "NavMeshAgent", 
	       description = "Does the agent currently have a path?",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-hasPath.html")]
	[System.Serializable]
	public class HasPath : StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("NavMeshAgent to use.")]
		public ObjectParameter gameObject;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
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
			return agent.hasPath == equals.Value;
		}
	}
}