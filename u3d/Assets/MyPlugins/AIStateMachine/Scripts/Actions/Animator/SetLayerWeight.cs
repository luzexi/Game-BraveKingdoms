using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityAnimator{
	[Info (category = "Animator",  
	       description = "Sets the layer's current weight.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Animator.SetLayerWeight.html")]
	[System.Serializable]
	public class SetLayerWeight : AnimatorAction {
		[Tooltip("Layer index containing the destination state.")]
		public IntParameter layer;
		[Tooltip("The weight of the layer.")]
		public FloatParameter weight;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!enabled) {
				return;			
			}
			animator.SetLayerWeight (layer.Value, weight.Value);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			animator.SetLayerWeight (layer.Value, weight.Value);
		}
	}
}