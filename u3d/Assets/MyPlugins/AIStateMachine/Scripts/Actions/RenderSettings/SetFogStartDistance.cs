using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Sets the starting distance of linear fog.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-fogStartDistance.html")]
	[System.Serializable]
	public class SetFogStartDistance : StateAction {
		[Tooltip("Fog starting distance to set.")]
		public FloatParameter startDistance;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.fogStartDistance = startDistance.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.fogStartDistance = startDistance.Value;
		}
	}
}