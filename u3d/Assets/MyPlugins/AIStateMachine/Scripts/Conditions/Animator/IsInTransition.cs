using UnityEngine;
using System.Collections;

namespace StateMachine.Condition.UnityAnimator{
	[Info (category = "Animator", 
	       description = "Is the specified AnimatorController layer in a transition.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.IsInTransition.html")]
	[System.Serializable]
	public class IsInTransition : StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject to test.")]
		public ObjectParameter target;
		[Tooltip("The layer to test.")]
		public IntParameter layer;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		private Animator animator;
		
		public override void OnEnter ()
		{
			if (target.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+target.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}
			
			animator = ((GameObject)target.Value).GetComponent<Animator> ();
			if (animator == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the Animator component on the GameObject. Condition disabled!");
			}
		}
		
		public override bool Validate ()
		{
			if(animator != null){

				return animator.IsInTransition(layer.Value) == equals.Value;
			}
			return false;
		}
	}
}