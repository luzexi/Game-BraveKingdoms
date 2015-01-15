using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Sets the rendering path of a camera.",
	       url = "http://docs.unity3d.com/ScriptReference/Camera-renderingPath.html")]
	[System.Serializable]
	public  class SetRenderingPath : CameraAction {
		[Tooltip("RenderingPath to set.")]
		public RenderingPath renderingPath;
		
		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.renderingPath = renderingPath;
		}
	}
}