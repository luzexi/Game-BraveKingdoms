using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Sets the translative weight of an IK goal (0 = at the original animation before IK, 1 = at the goal).",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKPositionWeight.html")]
	[System.Serializable]
	public class SetIKPositionWeight : AnimatorAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[Tooltip("The translative weight.")]
		public FloatParameter value;

		public override void OnAnimatorIK (int layer)
		{
			animator.SetIKPositionWeight (goal, value.Value);
		}
	}
}