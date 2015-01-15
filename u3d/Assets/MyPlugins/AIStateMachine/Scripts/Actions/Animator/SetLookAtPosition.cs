using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Sets the look at position.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetLookAtPosition.html")]
	[System.Serializable]
	public class SetLookAtPosition : AnimatorAction {
		[Tooltip("The position to lookAt.")]
		public Vector3Parameter position;
		[RequiredField(DefaultReference.None,false)]
		[ObjectType(typeof(GameObject))]
		[Tooltip("Optional sets to targets position.")]
		public ObjectParameter target;


		public override void OnAnimatorIK (int layer)
		{
			if (target != null && !target.isNone && target.Value != null) {
				animator.SetLookAtPosition (((GameObject)target.Value).transform.position);
			} else {
				animator.SetLookAtPosition (position.Value);
			}
		}
	}
}