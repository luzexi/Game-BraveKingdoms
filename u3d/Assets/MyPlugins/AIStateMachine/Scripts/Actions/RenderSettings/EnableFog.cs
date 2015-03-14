using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Enable or disable fog.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-fog.html")]
	[System.Serializable]
	public class EnableFog : StateAction {
		[Tooltip("True to enable fog.")]
		public BoolParameter value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.fog = value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.fog = value.Value;
		}
	}
}