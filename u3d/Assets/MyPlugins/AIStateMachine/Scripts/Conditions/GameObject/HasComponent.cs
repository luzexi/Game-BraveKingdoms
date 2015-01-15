using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "GameObject",    
	       description = "Returns true if the GameObject has a specified component.",
	       url = "")]
	[System.Serializable]
	public class HasComponent : StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject to test.")]
		public ObjectParameter gameObject;
		[Tooltip("Component to check.")]
		public StringParameter component;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+gameObject.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}
		}
		
		public override bool Validate ()
		{
			return ((GameObject)gameObject.Value).GetComponent(component.Value)== equals.Value;
		}
	}
}