using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Sets the color of the ambient light.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-ambientLight.html")]
	[System.Serializable]
	public class SetAmbientLight : StateAction {
		[Tooltip("Color to set.")]
		public ColorParameter color;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.ambientLight = color.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.ambientLight = color.Value;
		}
	}
}