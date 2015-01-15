using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator", 
	       description = "Set look at weights.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetLookAtWeight.html")]
	[System.Serializable]
	public class SetLookAtWeight : AnimatorAction {
		[Tooltip("(0-1) the global weight of the LookAt, multiplier for other parameters.")]
		public FloatParameter weight;
		[Tooltip("(0-1) determines how much the body is involved in the LookAt.")]
		public FloatParameter bodyWeight;
		[Tooltip("(0-1) determines how much the head is involved in the LookAt.")]
		public FloatParameter headWeight;
		[Tooltip("(0-1) determines how much the eyes is involved in the LookAt.")]
		public FloatParameter eyesWeight;
		[Tooltip("(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).")]
		public FloatParameter clampWeight;
		
		public override void OnAnimatorIK (int layer)
		{
			animator.SetLookAtWeight (weight.Value,bodyWeight.Value,headWeight.Value,eyesWeight.Value,clampWeight.Value);
		}
	}
}