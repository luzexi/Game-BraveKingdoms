using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Sets the rotational weight of an IK goal (0 = rotation before IK, 1 = rotation at the IK goal).",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKRotationWeight.html")]
	[System.Serializable]
	public class SetIKRotationWeight : AnimatorAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[Tooltip("The rotational weight.")]
		public FloatParameter value;
		
		public override void OnAnimatorIK (int layer)
		{
			animator.SetIKRotationWeight (goal, value.Value);
		}
	}
}