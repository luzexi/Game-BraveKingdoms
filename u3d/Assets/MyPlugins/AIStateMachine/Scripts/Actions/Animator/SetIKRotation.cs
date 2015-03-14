using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",  
	       description = "Sets the rotation of an IK goal.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKRotation.html")]
	[System.Serializable]
	public class SetIKRotation : AnimatorAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[Tooltip("The euler angles to set.")]
		public Vector3Parameter euler;
		
		public override void OnAnimatorIK (int layer)
		{
			animator.SetIKRotation (goal, Quaternion.Euler(euler.Value));
		}
	}
}