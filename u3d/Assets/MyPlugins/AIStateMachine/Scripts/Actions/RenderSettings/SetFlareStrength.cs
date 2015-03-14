using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Sets the flare strength.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-flareStrength.html")]
	[System.Serializable]
	public class SetFlareStrength : StateAction {
		[Tooltip("Strength to set.")]
		public FloatParameter strength;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.flareStrength = strength.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.flareStrength = strength.Value;
		}
	}
}