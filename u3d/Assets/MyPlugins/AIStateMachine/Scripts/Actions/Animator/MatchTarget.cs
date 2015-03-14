using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",    
	       description = "Automatically adjust the gameobject position and rotation so that the AvatarTarget reaches the matchPosition when the current state is at the specified progress.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.MatchTarget.html")]
	[System.Serializable]
	public class MatchTarget : AnimatorAction {
		[Tooltip("The body part that is involved in the match")]
		public AvatarTarget bodyPart;
		[Tooltip("The position we want the body part to reach.")]
		public Vector3Parameter matchPosition;
		[Tooltip("The rotation in which we want the body part to be.")]
		public Vector3Parameter matchRotation;
		[Tooltip("The MatchTargetWeightMask Position XYZ weight")]
		public Vector3Parameter positionWeight;
		[Tooltip("The MatchTargetWeightMask Rotation weight")]
		public FloatParameter rotationWeight;
		[Tooltip("Start time within the animation clip (0 - beginning of clip, 1 - end of clip)")]
		public FloatParameter startNormalizedTime;
		[Tooltip("End time within the animation clip (0 - beginning of clip, 1 - end of clip), values greater than 1 can be set to trigger a match after a certain number of loops. Ex: 2.3 means at 30% of 2nd loop")]
		public FloatParameter targetNormalizedTime;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			DoMatchTarget ();
		}

		public override void OnUpdate ()
		{
			DoMatchTarget ();
		}

		void DoMatchTarget()
		{		
			MatchTargetWeightMask weightMask = new MatchTargetWeightMask(positionWeight.Value, rotationWeight.Value);
			animator.MatchTarget(matchPosition.Value,Quaternion.Euler( matchRotation.Value), bodyPart, weightMask, startNormalizedTime.Value, targetNormalizedTime.Value);
		}
		
	}
}