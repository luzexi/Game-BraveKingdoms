using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "RenderSettings",   
	       description = "Sets the global skybox.",
	       url = "http://docs.unity3d.com/ScriptReference/RenderSettings-skybox.html")]
	[System.Serializable]
	public class SetSkybox : StateAction {
		[ObjectType(typeof(Material))]
		[Tooltip("Skybox to set.")]
		public ObjectParameter skybox;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.skybox = (Material)skybox.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.skybox =(Material) skybox.Value;
		}
	}
}