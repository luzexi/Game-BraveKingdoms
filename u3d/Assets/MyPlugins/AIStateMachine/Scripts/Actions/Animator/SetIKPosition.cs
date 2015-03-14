using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",  
	       description = "Sets the position of an IK goal.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKPosition.html")]
	[System.Serializable]
	public class SetIKPosition : AnimatorAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[Tooltip("The position in world space.")]
		public Vector3Parameter position;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.None,false)]
		[Tooltip("Optional sets to targets position.")]
		public ObjectParameter target;

		public override void OnAnimatorIK (int layer)
		{
			if (target != null && !target.isNone && target.Value != null) {
				animator.SetIKPosition (goal, ((GameObject)target.Value).transform.position);
			} else {
				animator.SetIKPosition (goal, position.Value);
			}
		}
	}
}