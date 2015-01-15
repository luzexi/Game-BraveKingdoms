using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "GameObject",    
	       description = "The local active state of this GameObject.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/GameObject-activeSelf.html")]
	[System.Serializable]
	public class IsActive : StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Required,false)]
		[Tooltip("GameObject to test.")]
		public ObjectParameter target;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;

		public override void OnEnter ()
		{
			if (target.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+target.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}
		}

		public override bool Validate ()
		{
			return ((GameObject)target.Value).activeSelf== equals.Value;
		}
	}
}