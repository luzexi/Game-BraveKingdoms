using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Sets the halo strength.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-haloStrength.html")]
	[System.Serializable]
	public class SetHaloStrength : StateAction {
		[Tooltip("Strength to set.")]
		public FloatParameter strength;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.haloStrength = strength.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.haloStrength = strength.Value;
		}
	}
}