using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Sets the flare fade speed.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-flareFadeSpeed.html")]
	[System.Serializable]
	public class SetFlareFadeSpeed : StateAction {
		[Tooltip("Speed to set.")]
		public FloatParameter speed;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.flareFadeSpeed = speed.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.flareFadeSpeed = speed.Value;
		}
	}
}