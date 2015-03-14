using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Sets the color of the fog.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-fogColor.html")]
	[System.Serializable]
	public class SetFogColor : StateAction {
		[Tooltip("Color of the fog.")]
		public ColorParameter color;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.fogColor = color.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.fogColor = color.Value;
		}
	}
}